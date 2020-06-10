# YOLOv3 nGPU ONNX model

The following instructions will enable you to run a [YOLOv3](http://pjreddie.com/darknet/yolo/) [ONNX](http://onnx.ai/) model on Live Video Analytics (LVA) using Jupyter notebooks. This sample is specific for GPU accelerated IoT Edge devices. 

Note: References to third-party software in this repo are for informational and convenience purposes only. Microsoft does not endorse nor provide rights for the third-party software. For more information on third-party software please see the links provided above.

## Prerequisites
To get started with this sample, clone the [Live Video Analytics repository](/utilities/video-analysis/jupyter) into your machine and follow the steps below:
1. Install the [requirements for running LVA on Jupyter](/utilities/video-analysis/jupyter/01_requirements.md).
2. Set up the [deployment and test environment on Jupyter](/utilities/video-analysis/jupyter/02_setup_environment.ipynb).
3. Create the [required Azure services](/utilities/video-analysis/jupyter/03_create_azure_services.ipynb).
4. Create an [Azure Virtual Machine](/utilities/video-analysis/jupyter/04_create_vm_iotedge_device.ipynb) if you
    * do not have a physical IoT Edge device or 
    * want to use a VM to test this sample

## Getting Started
<!--
    Change this step depending on the kind of sample: CPU (/utilities/video-analysis/jupyter/05_install_iotedge_runtime_cpu.md) or GPU (/utilities/video-analysis/jupyter/06_install_iotedge_runtime_gpu.md)
-->
If you have NVidia GPU accelerated IoT Edge devices, install [the drivers for your nGPU and configure Azure IoT Edge runtime](/utilities/video-analysis/jupyter/06_install_iotedge_runtime_gpu.md). 

## Building a Docker Image of the Inference Server
<!--
    Change the next few steps based on specific instructions.
-->
The following section explains how to build a Docker image of the inference server that uses AI logic (i.e., YOLOv3 for object detection).
1. Create a [YOLOv3 inference engine](/utilities/video-analysis/jupyter/yolov3-ngpu-onnx/01_create_inference_engine.ipynb). The inference engine wrapper will retrieve image data, analyse it, and return the analysis as output.
2. Create a [local Docker image](/utilities/video-analysis/jupyter/yolov3-ngpu-onnx/02_create_local_container_image.ipynb) to containerize the ML solution. The ML solution consists of a web application and an inference server.
3. Before uploading the Docker image, [test the image locally](/utilities/video-analysis/jupyter/yolov3-ngpu-onnx/03_local_test.ipynb).

## Deployment
Once the Docker image has been tested successfully, [upload the container image](/utilities/video-analysis/jupyter/07_upload_container_image_to_acr.ipynb) to Azure Container Registry (ACR). After the image has been successfully uploaded on ACR, [deploy LVA and the inference server modules](/utilities/video-analysis/jupyter/08_deploy_iotedge_modules.ipynb) to an IoT Edge device.


## TO BE DETERMINED
08 setup deployment manifest 
* May include RTSP simulator (in cased dont have IP cam) 
  * If this is the case, than which sample video file should be played as virtual IP cam content? 
  * How these files to be copied into edge device. 
  * Here we should guide accordingly
* How inference server or any other (like LVA) module deployment settings are set.

09 deploy media graph

10 Check if all modules works fine, if we get inference results