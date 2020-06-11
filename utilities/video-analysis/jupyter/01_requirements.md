# 1. Requirements for LVA Jupyter Notebook Samples 

## 1.1. Installing Required Tools
To run LVA on Jupyter notebooks, you will first need to install the following tools. 

1. There are many ways to run, manage, and update Jupyter notebooks. Out of the many options, we recommend using Visual Studio Code (VSCode) because it has extensions for running and managing IoT devices as well. Install [Visual Studio Code](https://code.visualstudio.com/) if you do not already have it installed.  

2. To run the Jupyter notebooks, you will need to have Python installed. If Python has not been installed on your machine, you should [install Python](https://www.python.org/downloads/). We recommend that you install Python 3 version 6 or above, as this sample was prepared using Python 3.6.2. Installing the latest version of Python should also install the latest version of Pip 3. Pip is a package management system used to install and manage software packages written in Python. 

   If you are using an Ubuntu machine to run this sample, Python may already be pre-installed. You can check if you already have Python installed by running the commands below:
    ```
    python --version
    ```
    ```
    python3 --version
    ``` 

    You can also check which version of Pip you have by running the commands below:
    ```
    pip --version
    ```
    ```
    pip3 --version
    ``` 

3. If you have multiple Python installations, such as Python 2.7 (which comes pre-installed in many Linux machines), make sure you are using the appropriate version of pip. Use the command `pip` for Python 2 or `pip3` for Python 3. Based on the version of Python and Pip you are running, you may need to update the code cells below with either `pip` or `pip3`.

4. Open Visual Studio Code and install the following extensions:  
    - [Azure IoT Tools](https://marketplace.visualstudio.com/items?itemName=vsciot-vscode.azure-iot-tools)  
    - [Python extension](https://marketplace.visualstudio.com/items?itemName=ms-python.python)  
    
## 1.2. Installing Jupyter
To get started with Jupyter on VSCode, you first need to have Jupyter installed. 

In VSCode, open a terminal window and run either command based on your version of Pip.
    ```
    pip install jupyter 
    ```
    ```
    pip3 install jupyter
    ```
## 1.3. Working with Jupyter Notebooks on VSCode
If you are not familiar with running Jupyter notebooks, you should view this tutorial on running [Jupyter on VSCode](https://code.visualstudio.com/docs/python/jupyter-support). When you are running Jupyer on VSCode, be sure to activate the right Python environment for VSCode by using the Command Palette (`Ctrl+Shift+P`) and searching for `Python: Select Interpreter`. Choose the appropriate version of Python that matches your needs. To review, we prepared this sample using Python 3.6.2 and Pip 3.

<img src="documents/python_interpreter.png" width=500px/>  

In this sample, you will be interacting with Azure. If you do not have an active Azure subscription, you can [create a free Azure account](https://azure.microsoft.com/free/?WT.mc_id=A261C142F). We will mainly be interacting with Azure through Jupyter, but for this to work, you will need to install the [Azure command-line interface (CLI)](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest).

> <span style="color:red; font-weight: bold; font-size:1.1em;"> [!IMPORTANT] </span> 
> If you are using the [Azure CLI for Linux](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-apt?view=azure-cli-latest), you may run into issues later related to account permissions. For example, we will be running Docker later in this sample. Instead of the command `sudo docker`, we prefer using the command `docker` without the `sudo` command. To run Docker commands on Linux without the `sudo` command, follow the Docker instructions for [managing Docker as a non-root user](https://docs.docker.com/install/linux/linux-postinstall/). Afterwards, you will have to log out from your PC and log back in.

## 1.4. Next Steps
In the following sections of this sample, there will be descriptions and instructions in Markdown cells in each of the Jupyter notebooks. Please carefully read these desctiptions and instructions before running the code cells, in order to ensure successful execution of the sample.

Moreover, we refer to three different environments later in this sample. Here are descriptions for each of them for future reference:
  
1. Azure Cloud Services - cloud-based services run on Azure Datacenters  
2. Development PC - the machine you are currently using to run this sample. This PC should have the required tools mentioned above.  
3. IoT Edge Device - another machine (be it a virtual machine or a computationally light powered mini PC) used to run LVA on the Edge. This IoT Edge device must be installed with a Debian-based Unix system with x64/AMD64 architecture. ARM processors are not supported yet.  

Per your preference, environments 1 and 2 can be the same machine, i.e., developing, debugging, and deploying this sample all on the same IoT Edge device.

> [!NOTE]  
> All of the commands in this sample should work as intended on machines running Ubuntu 18.04 and MacOS. If you are using a machine running Windows as your development PC, you can try either of the following solutions:
> <br><br>Option 1: Install [Git Bash](https://git-scm.com/downloads) and run all the proceeding Jupyter notebooks by first running the command `jupyter notebook` on Git Bash, instead of using VSCode. 
> <br><br>Option 2: Turn on the [Windows Subsystem for Linux (WSL) setting](https://code.visualstudio.com/remote-tutorials/wsl/enable-wsl). Then, download [Ubuntu 18.04 from the Microsoft store](https://docs.microsoft.com/en-us/windows/wsl/install-win10#install-your-linux-distribution-of-choice). Finally, [install Jupyter](https://jupyter.org/install) on your WSL (remember to use `pip3` instead of `pip`).

After having all the requirements from this section satisfied, clone [this project repository](/) into your local machine.


and open the repository with VSCode. You can continue with next sections (which is a Jupyter notebook file) in Visual Studio Code. Here is a [VSCode Jupyter Notebooks tutorial](https://code.visualstudio.com/docs/python/jupyter-support) that you may want to check if you dont have any Jupyter notebook experience before.

