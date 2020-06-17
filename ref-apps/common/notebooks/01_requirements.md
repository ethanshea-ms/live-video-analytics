# 1. Requirements and Installations

This sample consists of Python Jupyter Notebook files. This sample also requires a set of tools and dependent additional libraries to run it. 

Here is the list of items you need to have this sample up and running:
- You can use either Windows (e.g., Windows 10) or Linux (e.g., Ubuntu 18.04) as the development machine. However, if you are using a VM as your development machine, do not use Hyper-V.
- Out of many options, we will recommend the use of [Visual Studio Code](https://code.visualstudio.com/) for managing, updating and running the Jupyter Notebooks.  

- Python: New Ubuntu installation already comes with pre-installed python programming environment. You can check from a terminal window by typing:  
```
python --version
```
or
```
python3 --version
```  
Output of the above commands should be version Python 3.6 or above.

- If you have multiple Python, including pre-installed python 2.7 (for example, on Ubuntu or macOS), make sure you are using the correct `pip` or `pip3`. In the code cells in the subsequent sections of this sample, update pip or pip3 calls according to the pip installation you have.

- Install [Visual Studio Code](https://code.visualstudio.com/docs/setup/setup-overview) first and then add the following extensions:  
    - [Azure IoT Tools](https://marketplace.visualstudio.com/items?itemName=vsciot-vscode.azure-iot-tools) extension  
    - Python: [Python extension](https://marketplace.visualstudio.com/items?itemName=ms-python.python)  
    - Visual Studio Code supports working with [Jupyter Notebooks](https://jupyter-notebook.readthedocs.io/en/latest/) natively. Please make sure you have a Python environment in which you've installed the [Jupyter package](https://pypi.org/project/jupyter/).  

- IoT Edge Runtime  (we will guide how to install it in the next sections)

- In VSCode Jupyter Notebook project, be sure to select the right Python version (if you have multiple Python installations). [Here](https://code.visualstudio.com/docs/python/environments) you can find instructions to specificy Python version.  
- [The Azure command-line interface (CLI)](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-apt?view=azure-cli-latest)  

- <span style="color:red; font-weight: bold; font-size:1.1em;"> [!Important] </span> Instead of using "sudo docker ..." we prefered to use "docker ..." without preceeding "sudo" command. To do so, follow the instructions [here.](https://docs.docker.com/install/linux/linux-postinstall/). Do not forget to logout and login back as mentioned in the instructions...

We prepared and tested this sample with:
- Python 3.6.9  
- Pip3  

There are jupyter notebook code cells with descriptions. Please read these desctiptions for successful execution of the sample.  

In this sample we refer to 3 different environments:  
1- Azure Cloud Services in the Azure Datacenters.  
2- Development machine with above required development resources & tools.  
3- IoT Edge Device (another regular machine, Virtual Machine or computationally light mini PC). (this machine must be Ubuntu OS installed, x64/AMD64 architecture, currently we do not support ARM yet.)  

Per your preference, above items 2 and 3 might be the same enviroment (i.e. we may develop, debug, deploy this sample on the same IoT Edge device).

After having all prerequisites satisfied, clone this project repository into your machine and open with Visual Studio Code. You can continue with next sections (which is a Jupyter Notebook file) in Visual Studio Code. Here is a [VSCode Jupyter Notebooks tutorial](https://code.visualstudio.com/docs/python/jupyter-support) that you may want to check if you do not have any Jupyter Notebook experience before.