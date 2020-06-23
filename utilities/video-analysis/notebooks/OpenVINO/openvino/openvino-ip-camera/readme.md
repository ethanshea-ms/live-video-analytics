# LVA OpenVINO™ Sample on Jupyter Notebooks 
The following instructions will enable you to run a [OpenVINO™](https://software.intel.com/content/www/us/en/develop/tools/openvino-toolkit.html) model on Live Video Analytics (LVA) using Jupyter notebooks. Use this sample if you wish to connect multiple IP cameras to your IoT Edge device. 

## Prerequisites
1. Install the [requirements for running LVA on Jupyter](../../../common/requirements.md) on your development PC.
2. After installing all of the requirements, [clone](https://code.visualstudio.com/Docs/editor/versioncontrol#_cloning-a-repository) the [LVA repository](/../../) locally into your development PC and open the repository with VSCode. 
3. Locate this Readme page in your local repository and continue reading the following sections on VSCode. You can preview Markdown (`.md`) pages by pressing `Ctrl+Shift+V` to open a full-screen window or by clicking the preview button on the top toolbar in VSCode.  
   
   <img src="../../../../../../images/_markdown_preview.png" width=200px/> 
   <br>

   > <span>[!NOTE]</span>
   > For pictures to render on VSCode, you must have the entire [live-video-analytics](/../..) folder open in your VSCode workspace.
   
## Getting Started
1. On VSCode, [set up the environment](../../../common/setup_environment.ipynb) so that we can test and deploy LVA.
   ><span>[!NOTE]</span>
   >Jupyter notebooks (`.ipynb`) may take several seconds to render in VSCode.
2. Create the required [Azure services](../../../common/create_azure_services.ipynb).
3. You will need a development PC and also an IoT Edge device to run LVA containers. 
   * If you have a physical IoT Edge device, you can proceed to [set up your IoT Edge device](../../../common/setup_iotedge_device.md).
   * If you don't have a physical IoT Edge device, you can create an [Azure virtual machine](../../../common/create_azure_vm.ipynb).
<!--
    Change the following steps based on specific instructions.
-->

## NEXT STEPS IN DEVELOPMENT