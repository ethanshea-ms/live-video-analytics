# Jupyter Notebook Samples
This repository contains Jupyter notebook samples for Live Video Analytics (LVA). To get started, click on any of the samples listed in the table below.  

## List of samples
| # | Name       | Extension | Accelerator| Description | Passed<sup>i</sup> |
|:---:|:---:        |:---:       |:---:        |:---       |:---:       |
| 1 | [Yolo V3](Yolo/yolov3/yolov3-http-icpu-onnx/readme.md)             | HTTP      | iCPU | LVA module using YoloV3, a neural network for real-time object detection, that complies with the Open Neural Network Exchange (ONNX). Follow this sample if your solution requires an Intel CPU accelerated IoT Edge device with connection through HTTP. | |
| 2 | [Tiny Yolo V3](Yolo/yolov3/tinyyolov3-http-icpu-onnx/readme.md)    | HTTP      | iCPU | LVA module using Tiny YoloV3, a lightweight variant of the Yolo V3 neural network model, that complies with the Open Neural Network Exchange (ONNX). Follow this sample if your solution requires an Intel CPU accelerated IoT Edge device with connection through HTTP. | |
| 3 | [Tiny Yolo V3](Yolo/yolov3/tinyyolov3-grpc-icpu-onnx/readme.md)                    | gRPC      | iCPU | LVA module using Tiny YoloV3, a lightweight variant of the Yolo V3 neural network model, that complies with the Open Neural Network Exchange (ONNX). Follow this sample if your solution requires an Intel CPU accelerated IoT Edge device with connection through gRPC. gRPC is a remote procedure call that efficiently connects services in and across data centers with pluggable support for load balancing, tracing, health checking and authentication. | |
| 4 | [Yolo V3](Yolo/yolov3/yolov3-http-ngpu-onnx/readme.md)             | HTTP      | nGPU |  LVA module using YoloV3, a neural network for real-time object detection, that complies with the Open Neural Network Exchange (ONNX). Follow this sample if your solution requires an NVidia GPU accelerated IoT Edge device with connection through HTTP. | 1 |

## Test specifications<sup>i</sup>:
| Test Case | Development PC<sup>a</sup>                            | IoT Edge Device<sup>b</sup>   |
| :---      | :---                                                  | :---                          |
| 1         | Azure VM<sup>*</sup><br>-OS: Ubuntu 18.04<br>-Python 3.6.9, Pip 3 | Azure VM<sup>*</sup><br>-OS: Ubuntu 18.04 |
| 2         | Physical PC<br>-OS: MacOS 15<br>-Python 3.6.9, Pip 3 | Azure VM<sup>*</sup><br>-OS: Ubuntu 18.04 |
| 3         | Physical PC<br>-OS: Windows 10 with<br> [WSL Ubuntu 18.04](https://docs.microsoft.com/en-us/windows/wsl/about)<br>-Python 3.6.9, Pip 3 | Azure VM<sup>*</sup><br>-OS: Ubuntu 18.04 |
| 4         | Physical PC<br>-OS: Windows 10 with Git Bash<br>-Python 3.8.3, Pip 3 | Azure VM<sup>*</sup><br>-OS: Ubuntu 18.04 |  

<sup>*</sup> [Create Azure Virtual Machine](commons/04_create_vm_iotedge_device.ipynb) section has the instructions for creating Azure Virtual Machine.

## Terminology
Throughout the samples, we refer to three different terms. Here are descriptions for each of them for future reference:

<ol type="a">
  <li>Development PC: the machine you are currently using to run this sample.</li>
  <li>IoT Edge Device: another machine (be it a virtual machine or a computationally light powered mini PC) used to run LVA on the Edge. This IoT Edge device must be installed with a Debian-based Unix system with x64/AMD64 architecture. ARM processors are not supported yet.  </li>
  <li>Azure Cloud Services: cloud-based services run on Azure datacenters (e.g., Azure Media Services, Azure Storage).  </li>
</ol>

Per your preference, your development PC and your IoT Edge device can be the same machine (i.e., developing, debugging, and deploying this sample all on the same IoT Edge device).
