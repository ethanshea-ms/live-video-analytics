# YoloV3 nGPU ONNX model
The following instructions will enable you to run a [YoloV3](http://pjreddie.com/darknet/yolo/) [ONNX](http://onnx.ai/) model on Live Video Analytics (LVA) using Jupyter notebooks. This sample is specific for Nvidia GPU accelerated IoT Edge devices. 

Note: References to third-party software in this repo are for informational and convenience purposes only. Microsoft does not endorse nor provide rights for the third-party software. For more information on third-party software please see the links provided above.

## Prerequisites
To get started with this sample, clone the [Live Video Analytics repository](/) into your machine and follow the steps below:
1. Install the [requirements for running LVA on Jupyter](/utilities/video-analysis/jupyter/01_requirements.md).
2. Set up the [deployment and test environment on Jupyter](/utilities/video-analysis/jupyter/02_setup_environment.ipynb).
3. Create the [required Azure services](/utilities/video-analysis/jupyter/03_create_azure_services.ipynb).

## Getting Started
<!--
    Change the following steps depending on the kind of sample: CPU (/utilities/video-analysis/jupyter/05_install_iotedge_runtime_cpu.md) or GPU (/utilities/video-analysis/jupyter/06_install_iotedge_runtime_gpu.md)
-->
To get started, create an [Azure Virtual Machine](/utilities/video-analysis/jupyter/04_create_vm_iotedge_device.ipynb) if you
    * do not have a physical IoT Edge device, or 
    * want to use a VM to test this sample
> [!NOTE]
> If you want to run the following sections, you must create a GPU-accelerated VM such as the Standard_NC6 VM, which has an NVidia GPU.
Once you have created your VM, check to see what [type of GPU](https://docs.microsoft.com/en-us/azure/virtual-machines/sizes-gpu?toc=/azure/virtual-machines/linux/toc.json&bc=/azure/virtual-machines/linux/breadcrumb/toc.json) comes with your VM. If your VM has an NVidia GPU, install [these IoT Edge runtime and the required drivers and tools for your NVidia GPU](/utilities/video-analysis/jupyter/06_install_iotedge_runtime_gpu.md). 

## Building a Docker Image of the Inference Server
<!--
    Change the following steps based on specific instructions.
-->
The following section explains how to build a Docker image of the inference server that uses AI logic (i.e., YoloV3 for object detection).
1. Create a [YoloV3 inference engine](/utilities/video-analysis/jupyter/yolov3-ngpu-onnx/01_create_inference_engine.ipynb). The inference engine wrapper will retrieve image data, analyse it, and return the analysis as output.
2. Create a [local Docker image](/utilities/video-analysis/jupyter/yolov3-ngpu-onnx/02_create_local_container_image.ipynb) to containerize the ML solution. The ML solution consists of a web application and an inference server.
3. Before uploading the Docker image, [test the image locally](/utilities/video-analysis/jupyter/yolov3-ngpu-onnx/03_local_test.ipynb).

## Deployment
Once the Docker image has been tested successfully, [upload the container image](/utilities/video-analysis/jupyter/07_upload_container_image_to_acr.ipynb) to Azure Container Registry (ACR). After the image has been successfully uploaded on ACR, [deploy LVA and the inference server modules](/utilities/video-analysis/jupyter/08_deploy_iotedge_modules.ipynb) to an IoT Edge device using a module deployment manifest. Finally, [deploy media graphs](/utilities/video-analysis/jupyter/09_deploy_media_graph.ipynb) to trigger the modules and test to see if the inference works as desired.
