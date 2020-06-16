# Jupyter Notebook Samples
This repository contains Jupyter notebook samples for Live Video Analytics (LVA). To get started, click on any of the samples listed in the table below.  

## List of samples
| Name       | Extension | Accelerator| Description | Passed<sup>i</sup> |
|:---:        |:---:       |:---:        |:---       |:---:       |
| [Yolo V3](yolov3/yolov3-http-icpu-onnx/readme.md)             | HTTP      | iCPU | LVA module using YoloV3, a neural network for real-time object detection, that complies with the Open Neural Network Exchange (ONNX). Follow this sample if your solution requires an Intel CPU accelerated IoT Edge device with connection through HTTP. | |
| [Tiny Yolo V3](yolov3/tinyyolov3-http-icpu-onnx/readme.md)    | HTTP      | iCPU | LVA module using Tiny YoloV3, a lightweight variant of the Yolo V3 neural network model, that complies with the Open Neural Network Exchange (ONNX). Follow this sample if your solution requires an Intel CPU accelerated IoT Edge device with connection through HTTP. | |
| [Tiny Yolo V3](yolov3/tinyyolov3-grpc-icpu-onnx/readme.md)                    | gRPC      | iCPU | LVA module using Tiny YoloV3, a lightweight variant of the Yolo V3 neural network model, that complies with the Open Neural Network Exchange (ONNX). Follow this sample if your solution requires an Intel CPU accelerated IoT Edge device with connection through gRPC. gRPC is a remote procedure call that efficiently connects services in and across data centers with pluggable support for load balancing, tracing, health checking and authentication. | |
| [Yolo V3](yolov3/yolov3-http-ngpu-onnx/readme.md)             | HTTP      | nGPU |  LVA module using YoloV3, a neural network for real-time object detection, that complies with the Open Neural Network Exchange (ONNX). Follow this sample if your solution requires an NVidia GPU accelerated IoT Edge device with connection through HTTP. | 1 |

## Test specifications<sup>i</sup>:

| Test Case   | OS          | OS Version                                                                      | Python Version    | Pip Version | Development PC<sup>b</sup> | IoT Edge Device<sup>c</sup>  |
| :---        |:---         | :---                                                                            |:--                | :---        | :---           | :---                    | 
| 1           | Ubuntu      | 18.04                                                                           | 3.6.9             | Pip3        | Azure VM       | Azure VM running Ubuntu 18.04 |
| 2           | Mac OS      | 15                                                                              | 3.6.9             | Pip3        | Physical PC       | Azure VM running Ubuntu 18.04 |
| 3           | Windows     | 10 ([WSL](https://docs.microsoft.com/en-us/windows/wsl/about) on Ubuntu 18.04)  | 3.6.9             | Pip3        | Physical PC    | Azure VM running Ubuntu 18.04 |
| 4           | Windows     | 10 (Git Bash)                                                                   | 3.8.3             | Pip3        | Physical PC    | Azure VM running Ubuntu 18.04 |

| Test Case | Development PC<sup>a</sup>                                                    | IoT Edge Device<sup>c</sup>      |
| :---      | :---                                                                          | :---                             |
| 1         | Azure VM<ul><li>OS: Ubuntu 18.04</li><li>Python 3.6.9</li><li>Pip 3</li></ul> | Azure VM<ul><li>OS: Ubuntu 18.04 |

## Terminology
Throughout the samples, we refer to three different terms. Here are descriptions for each of them for future reference:

<ol type="a">
  <li>Development PC: the machine you are currently using to run this sample.</li>
  <li>IoT Edge Device: another machine (be it a virtual machine or a computationally light powered mini PC) used to run LVA on the Edge. This IoT Edge device must be installed with a Debian-based Unix system with x64/AMD64 architecture. ARM processors are not supported yet.  </li>
  <li>Azure Cloud Services: cloud-based services run on Azure datacenters (e.g., Azure Media Services, Azure Storage).  </li>
</ol>

Per your preference, your development PC and your IoT Edge device can be the same machine (i.e., developing, debugging, and deploying this sample all on the same IoT Edge device).
