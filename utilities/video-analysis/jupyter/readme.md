# Jupyter Notebook Samples
This repository contains Jupyter notebook samples for Live Video Analytics (LVA). To get started, click on any of the samples listed in the table below.  

## List of samples

| Name       | Extension | Accelerator| Description | Passed<sup>1</sup> Tests |
|:---:        |:---:       |:---:        |:---       |:---       | :---: | :---: |
| [Yolo V3](yolov3-icpu-onnx/readme.md)             | HTTP      | iCPU | LVA module using Yolo V3, a neural network for real-time object detection, that complies with the Open Neural Network Exchange (ONNX). Follow this sample if your solution requires an Intel CPU accelerated IoT Edge device with connection through HTTP. | 1, 2 |
| [Tiny Yolo V3](tinyyolov3-icpu-onnx/readme.md)    | HTTP      | iCPU | LVA module using Tiny Yolo V3, a lightweight variant of the Yolo V3 neural network model, that complies with the Open Neural Network Exchange (ONNX). Follow this sample if your solution requires an Intel CPU accelerated IoT Edge device with connection through HTTP. |  1, 2 |
| [Tiny Yolo V3](http://aka.ms/)                    | gRPC      | iCPU | LVA module using Tiny Yolo V3, a lightweight variant of the Yolo V3 neural network model, that complies with the Open Neural Network Exchange (ONNX). Follow this sample if your solution requires an Intel CPU accelerated IoT Edge device with connection through gRPC. gRPC is a remote procedure call that efficiently connects services in and across data centers with pluggable support for load balancing, tracing, health checking and authentication. |  1, 2 |
| [Yolo V3](yolov3-ngpu-onnx/readme.md)             | HTTP      | nGPU |  LVA module using Yolo V3, a neural network for real-time object detection, that complies with the Open Neural Network Exchange (ONNX). Follow this sample if your solution requires an NVidia GPU accelerated IoT Edge device with connection through HTTP. |  1, 2 |


## Test specifications<sup>1</sup>:

| Test Case   | OS          | OS Version    | Python Version    | Pip Version |
| :---        | :---        | :---          | :---              | :--- |
| 1           | Ubuntu      | 18.04         | 3.6.2             | Pip3 |
| 2           | Mac OS      | 15            | 3.6.2             | Pip3 |
