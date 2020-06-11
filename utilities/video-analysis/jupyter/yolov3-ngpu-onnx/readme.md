# YoloV3 nGPU ONNX model
The following instructions will enable you to run a [YoloV3](http://pjreddie.com/darknet/yolo/) [ONNX](http://onnx.ai/) model on Live Video Analytics (LVA) using Jupyter notebooks. This sample is specific for Nvidia GPU accelerated IoT Edge devices. 

Note: References to third-party software in this repo are for informational and convenience purposes only. Microsoft does not endorse nor provide rights for the third-party software. For more information on third-party software please see the links provided above.

## Prerequisites
1. Install the [requirements for running LVA on Jupyter](/utilities/video-analysis/jupyter/01_requirements.md).
2. After installing all of the required tools and cloning the [LVA repository](/), have the repository open in a split-screen view so that you can continue following this sample while running the code. On VSCode, start by running the Jupyter notebook titled [02_setup_environment.ipynb](/utilities/video-analysis/jupyter/02_setup_environment.ipynb), which will set up a deployment and test environment on Jupyter. The notebook may take several minutes to load into Jupyter format.
3. Create the required Azure services by running the Jupyter notebook titled [03_create_azure_services.ipynb](/utilities/video-analysis/jupyter/03_create_azure_services.ipynb).

## Getting Started
<!--
    Change the following steps depending on the kind of sample: CPU (/utilities/video-analysis/jupyter/05_install_iotedge_runtime_cpu.md) or GPU (/utilities/video-analysis/jupyter/06_install_iotedge_runtime_gpu.md)
-->
To get started with your ML module, create an Azure Virtual Machine by running the Jupyter notebook titled [04_create_vm_iotedge_device.ipynb](/utilities/video-analysis/jupyter/04_create_vm_iotedge_device.ipynb) if you
    * do not have a physical IoT Edge device, or 
    * want to use a VM to test this sample
> [!NOTE]
> If you want to run the following sections, you must create a GPU-accelerated VM such as the Standard_NC6 VM, which has an NVidia GPU.
Once you have created your VM, check to see what [type of GPU](https://docs.microsoft.com/en-us/azure/virtual-machines/sizes-gpu?toc=/azure/virtual-machines/linux/toc.json&bc=/azure/virtual-machines/linux/breadcrumb/toc.json) comes with your VM. If your VM has an NVidia GPU, install [these IoT Edge runtime and the required drivers and tools for your NVidia GPU](/utilities/video-analysis/jupyter/06_install_iotedge_runtime_gpu.md). 

## Building a Docker Image of the Inference Server
<!--
    Change the following steps based on specific instructions.
-->
The following sections explain how to build a Docker image of the inference server that uses AI logic (i.e., YoloV3 for object detection) on a GPU-accelerated VM.
1. Create a YoloV3 inference engine by running the Jupyter notebook titled [yg1_create_inference_engine.ipynb] (/utilities/video-analysis/jupyter/yolov3-ngpu-onnx/yg1_create_inference_engine.ipynb). The inference engine wrapper will retrieve image data, analyse it, and return the analysis as output.
2. Create a local Docker image by running the Jupyter notebook titled [yg2_create_local_container_image.ipynb](/utilities/video-analysis/jupyter/yolov3-ngpu-onnx/yg2_create_local_container_image.ipynb) to containerize the ML solution. The ML solution consists of a web application and an inference server.
3. Before uploading the Docker image, test the image locally by running the Jupyer notebook titled [yg3_local_test.ipynb] (/utilities/video-analysis/jupyter/yolov3-ngpu-onnx/yg3_local_test.ipynb).

## Deployment
The following section will explain how to deploy the Docker image and run media graphs to get started with LVA. 

The image below summarizes the deployment process for LVA. As the dashed lines connecting the container registries and the Edge device grouping show, LVA can be utilized using containers hosted on the Internet, on a local network, or even on a local machine.

<img src="../documents/_architecture.png" width=500px/>  

To deploy your ML module on LVA, follow the steps below:

1. After you have tested your Docker image, upload the container image to Azure Container Registry (ACR) by running the Jupyter notebook titled [07_upload_container_image_to_acr.ipynb](/utilities/video-analysis/jupyter/07_upload_container_image_to_acr.ipynb). 
2. After the image has been successfully uploaded on ACR, deploy LVA and the inference server modules by running the Jupyter notebook titled [08_deploy_iotedge_modules.ipynb](/utilities/video-analysis/jupyter/08_deploy_iotedge_modules.ipynb) to an IoT Edge device using a module deployment manifest. 
3. Finally, deploy media graphs by running the Jupyter notebook titled [09_deploy_media_graph.ipynb](/utilities/video-analysis/jupyter/09_deploy_media_graph.ipynb) to trigger the modules and test to see if the inference works as desired.