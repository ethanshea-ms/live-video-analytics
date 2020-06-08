# 1. LVA Jupyter Notebook Samples' Requirements
You need to have the below list of requirements to run the Python Jupyter Notebook samples in this repository. Clone this repository into a machine with below requirements installed.

1. Out of many options, we will recommend the use of [Visual Studio Code](https://code.visualstudio.com/) for managing, updating and running the jupyter notebook samples in this repository.  

2. Python: New Ubuntu installation already comes with pre-installed python programming environment. You can check from a terminal window by typing:  
    ```
    python --version
    ```
    or
    ```
    python3 --version
    ```  

    Some samples may require specific version of Python. See project specific requirements for exceptions.

3. If you have multiple Python installations, including pre-installed python 2.7 (for example, on Ubuntu or macOS), make sure you are using the correct `pip` or `pip3`. In the following code cells of the samples, update pip or pip3 calls according to the pip installation you have.

4. Following [Visual Studio Code](https://code.visualstudio.com/) extensions:  
    - [Azure IoT Tools](https://marketplace.visualstudio.com/items?itemName=vsciot-vscode.azure-iot-tools)  
    - [Python extension](https://marketplace.visualstudio.com/items?itemName=ms-python.python)  
    - [Jupyter Notebook extension](https://code.visualstudio.com/docs/python/jupyter-support)  
        - So [Jupyter package](https://pypi.org/project/jupyter/)  

6. In case you have multiple Python installations, be sure to select the right Python version in notebook samples. [Here](https://code.visualstudio.com/docs/python/environments) you can find instructions on how to specificy a Python version.  

7. [The Azure command-line interface (CLI)](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-apt?view=azure-cli-latest)  

    - <span style="color:red; font-weight: bold; font-size:1.1em;"> [!Important] </span> Instead of using "sudo docker ..." we prefered to use "docker ..." without preceeding "sudo" command. To do so, follow the instructions [here](https://docs.docker.com/install/linux/linux-postinstall/). Dont forget to logout from PC and login back as mentioned in the instructions.

We prepared and tested this samples with:
- Python 3.6.2  
- Pip3  

Moreover, there are jupyter notebook code cells with preceding descriptive markdown cells. Please carefully read these desctiptions for successful execution of the samples.  

In these samples we refer to 3 different environments:  
1. Azure Cloud Services in the Azure Datacenters  
2. Development PC with above required development resources & tools  
3. IoT Edge Device (another regular PC, Virtual Machine or computationally light power mini PC). IoT Edge Device must be installed with Debia based Unix system, x64/AMD64 architecture. ARM processors are not supported yet.  

Per your preference, above items 2 and 3 might be the same enviroment, same PC. i.e. we develop, debug, deploy this sample on the same IoT Edge device.

After having all prerequisites satisfied, clone this project repository into your machine and open the repository with Visual Studio Code. You can continue with next sections (which is a Jupyter notebook file) in Visual Studio Code. Here is a [VSCode Jupyter Notebooks tutorial](https://code.visualstudio.com/docs/python/jupyter-support) that you may want to check if you dont have any Jupyter notebook experience before.