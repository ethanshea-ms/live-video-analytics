# Yolov3 nGPU ONNX model

The following instructions will enable you to run a [Yolov3](http://pjreddie.com/darknet/yolo/) [ONNX](http://onnx.ai/) model using [nginx](https://www.nginx.com/), [gunicorn](https://gunicorn.org/), [flask](https://github.com/pallets/flask), and [runit](http://smarden.org/runit/) on Jupyter notebooks.

Note: References to third-party software in this repo are for informational and convenience purposes only. Microsoft does not endorse nor provide rights for the third-party software. For more information on third-party software please see the links provided above.

## Getting Started
To get started with this sample, clone the [Live Video Analytics repository](/utilities/video-analysis/jupyter) into your machine.
1. Install the requirements for this sample by following [this guide](https://github.com/mustafakasap/live-video-analytics/blob/master/utilities/video-analysis/jupyter/01_requirements.md)
2. Set up the deployment and test environment by running the Jupyter notebook titled [02_setup_environment.ipynb](https://github.com/mustafakasap/live-video-analytics/blob/master/utilities/video-analysis/jupyter/02_setup_environment.ipynb)


## Introduction


follow sections:
01
02
03
04 (telling that in case user dont have physical device and want to us a VM for just testing the samples)

Per sample requirement (i.e. some samples may require CPU or GPU), we will guide here to follow 05 or 06...

before going with section 7, here specific to this sample, we will guide how to build a local docker image of the inference server with the AI logic (i.e. yolov3 object detection) specific to this sample. So at this point we have sample specific instructions to create the YoloV3 that runs on GPU... (earlier instrcutions are at https://github.com/mustafakasap/aix/tree/jupyternotebook_httpextension_nGPU_yolov3 )
complete this sample specific instructions under "yolov3-ngpu-onnx" folder, run notebooks 01, 02 and 03 under this folder to build a local container and test the container.


Once the user build local docker image for this sample and follow the local test instructions, he/she will continue with section 07
07

08 setup deployment manifest 
    - May include RTSP simulator (in cased dont have IP cam) If this is the case, than which sample video file should be played as virtual IP cam content? how these files to be copied into edge device. here we should guide accordingly
    - how inference server or any other (like LVA) module deployment settings are set.

09 deploy media graph

10 Check if all modules works fine, if we get inference results