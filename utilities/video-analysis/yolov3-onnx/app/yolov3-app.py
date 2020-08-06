# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.

from datetime import datetime
import io
import json
import os
import logging
import time
from typing import Tuple

from flask import Flask, Response, Request, abort, request
import numpy as np
import onnxruntime
from PIL import Image, ImageDraw, ImageFont
import requests

session = None
tags = []
output_dir = 'images'

def init_logging():
    gunicorn_logger = logging.getLogger('gunicorn.error')
    if gunicorn_logger != None:
        app.logger.handlers = gunicorn_logger.handlers
        app.logger.setLevel(gunicorn_logger.level)


# Called when the deployed service starts
def init_model():
    global session
    global tags
    global output_dir

    model_path = 'yolov3/yolov3.onnx'
    session = onnxruntime.InferenceSession(model_path) 

    tags_file = 'tags.txt'    
    with open(tags_file) as f:
        for line in f: 
            line = line.strip()
            tags.append(line) 

    if not os.path.exists(output_dir):
        os.mkdir(output_dir)
        
    app.logger.info('Model initialized')
    

def letterbox_image(image: Image, size: Tuple[int, int]):
    '''Resize image with unchanged aspect ratio using padding'''
    iw, ih = image.size
    w, h = size
    scale = min(w/iw, h/ih)
    nw = int(iw*scale)
    nh = int(ih*scale)

    image = image.resize((nw,nh), Image.BICUBIC)
    new_image = Image.new('RGB', size, (128,128,128))
    new_image.paste(image, ((w-nw)//2, (h-nh)//2))

    return new_image


def preprocess(image: Image):
    model_image_size = (416, 416)
    boxed_image = letterbox_image(image, tuple(reversed(model_image_size)))
    image_data = np.array(boxed_image, dtype='float32')
    image_data /= 255.
    image_data = np.transpose(image_data, [2, 0, 1])
    image_data = np.expand_dims(image_data, 0)
    
    return image_data


def postprocess(boxes, scores, indices, image_size: Tuple[int, int], object_type: str = None, confidenceThreshold: float = 0.0):
    detected_objects = []
    image_width, image_height = image_size
    
    for index_ in indices:
        # See https://github.com/onnx/models/tree/master/vision/object_detection_segmentation/yolov3#output-of-model for more details
        object_tag = tags[index_[1].tolist()]
        confidence = scores[tuple(index_)].tolist()
        y1, x1, y2, x2 = boxes[(index_[0], index_[2])].tolist()

        width = (x2 - x1) / image_width
        height = (y2 - y1) / image_height
        left = x1 / image_width
        top = y1 / image_height
        
        dobj = {
            "type" : "entity",
            "entity" : {
                "tag" : {
                    "value" : object_tag,
                    "confidence" : confidence
                },
                "box" : {
                    "l" : left,
                    "t" : top,
                    "w" : width,
                    "h" : height
                }
            }
        }

        if object_type is None:
            detected_objects.append(dobj)
        else:
            if (object_type == object_tag) and (confidence > confidenceThreshold):
                detected_objects.append(dobj)

    return detected_objects


def process_image(image: Image, object_type: str = None, confidence_threshold: float = 0.0):
    # Preprocess input according to the functions specified above
    image_data = preprocess(image)
    image_size = np.array([image.size[1], image.size[0]], dtype=np.float32).reshape(1, 2)

    inference_time_start = time.time()
    boxes, scores, indices = session.run(None, {"input_1": image_data, "image_shape": image_size})
    inference_time_end = time.time()
    inference_duration_s = inference_time_end - inference_time_start
    
    detected_objects = postprocess(boxes, scores, indices, image.size, object_type, confidence_threshold)
    return detected_objects, inference_duration_s


def draw_bounding_boxes(image: Image, detected_objects: list):
    objects_identified = len(detected_objects)
    
    image_width, image_height = image.size
    draw = ImageDraw.Draw(image)    

    textfont = ImageFont.load_default()
    
    for pos in range(objects_identified):       
        entity = detected_objects[pos]['entity'] 
        box = entity["box"]
        x1 = box["l"]
        y1 = box["t"]
        x2 = box["w"]
        y2 = box["h"]
        
        x1 = x1 * image_width
        y1 = y1 * image_height
        x2 = (x2 * image_width) + x1
        y2 = (y2 * image_height) + y1
        tag = entity['tag']
        object_class = tag['value']        

        draw.rectangle((x1, y1, x2, y2), outline = 'blue', width = 1)
        draw.text((x1, y1), str(object_class), fill = "white", font = textfont)
     
    return image


app = Flask(__name__)

def load_image(request: Request):
    try:
        image_data = io.BytesIO(request.get_data())
        image = Image.open(image_data)
    except Exception:
        abort(Response(response='Could not decode image', status=400))

    return image

# / routes to the default function which returns 'Hello World'
@app.route('/', methods=['GET'])
def defaultPage():
    return Response(response='Hello from Yolov3 inferencing based on ONNX', status=200)

@app.route('/stream/<id>')
def stream(id):
    respBody = ("<html>"
                "<h1>Stream with inferencing overlays</h1>"
                "<img src=\"/mjpeg/" + id + "\"/>"
                "</html>")

    return Response(respBody, status= 200)

# /score routes to scoring function 
# This function returns a JSON object with inference duration and detected objects
@app.route("/score", methods=['POST'])
def score():
    confidence = request.args.get('confidence', default = 0.0, type = float)
    object_type = request.args.get('object')
    stream = request.args.get('stream')

    image = load_image(request)
    detected_objects = process_image(image, object_type, confidence)

    if stream is not None:
        output_image = draw_bounding_boxes(image, detected_objects)

        image_buffer = io.BytesIO()
        output_image.save(image_buffer, format='JPEG')

        # post the image with bounding boxes so that it can be viewed as an MJPEG stream
        postData = b'--boundary\r\n' + b'Content-Type: image/jpeg\r\n\r\n' + image_buffer.getvalue() + b'\r\n'
        requests.post('http://127.0.0.1:80/mjpeg_pub/' + stream, data = postData)

    if len(detected_objects) > 0:
        respBody = {
            "inferences" : detected_objects
        }

        respBody = json.dumps(respBody)
        return Response(respBody, status= 200, mimetype ='application/json')
    else:
        return Response(status= 204)

# /score-debug routes to score_debug
# This function scores the image and stores an annotated image for debugging purposes
@app.route('/score-debug', methods=['POST'])
def score_debug():
    image = load_image(request)

    detected_objects, inference_duration_s = process_image(image)
    app.logger.info('Inference took %.2f seconds', inference_duration_s)

    output_image = draw_bounding_boxes(image, detected_objects)

    # datetime object containing current date and time
    now = datetime.now()
    
    output_image_file = now.strftime("%d_%m_%Y_%H_%M_%S.jpeg")
    output_image.save(output_dir + "/" + output_image_file)

    respBody = {
        "inferences" : detected_objects
    }
    
    return respBody

# /annotate routes to annotation function 
# This function returns an image with bounding boxes drawn around detected objects
@app.route('/annotate', methods=['POST'])
def annotate():
    image = load_image(request)

    detected_objects, inference_duration_s = process_image(image)
    app.logger.info('Inference took %.2f seconds', inference_duration_s)

    image = draw_bounding_boxes(image, detected_objects)
    
    image_bytes = io.BytesIO()        
    image.save(image_bytes, format = 'JPEG')        
    image_bytes = image_bytes.getvalue()

    return Response(response = image_bytes, status = 200, mimetype = "image/jpeg")

init_logging()
init_model()

if __name__ == '__main__':
    # Running the file directly
    app.run(host='0.0.0.0', port=8888)