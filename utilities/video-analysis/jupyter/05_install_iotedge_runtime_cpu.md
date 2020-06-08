# 5. Install IoT Edge runtime for just CPU accelerated IoT Edge Devices

If you are using a Virtual Machine, you can use the SSH connection string to create a terminal session over the VM. Or with your own preference of connection type, open a terminal window session on the IoT Edge device. Commands in the below steps should be executed on the iot edge device through the terminal session.

## 5.2 Install the Azure IoT Edge runtime

To be able to run below commands, you need to install the **curl** command line tool in case it is not already installed. To install *curl*, please use the following command:

```shell
sudo apt-get -y install curl
```

To install the IoT Edge Runtime, in order run the below commands in the terminal window. Be sure the following URL in the below commands reflects the right version of your OS in the IoT Edge Device:  
```
    https://packages.microsoft.com/config/ubuntu/<YOUR_OS_VERSION>/multiarch/prod.list
```



Commands to install the IoT Edge Runtime:

```shell
curl https://packages.microsoft.com/config/ubuntu/18.04/multiarch/prod.list > ./microsoft-prod.list
sudo cp ./microsoft-prod.list /etc/apt/sources.list.d/
curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg
sudo cp ./microsoft.gpg /etc/apt/trusted.gpg.d/
sudo apt-get -y update
sudo apt-get -y install moby-engine
sudo apt-get -y update
sudo apt-get -y install iotedge
```

## 5.3. Configure the IoT Edge Runtime service
You need to configure the IoT Edge Runtime service, so it will connect to the IoT Hub service in the cloud. To do so, you need IOT HUB connection string which looks like something:  

```
HostName=mkov01iothub.azure-devices.net;DeviceId=mkov01iotdevid;SharedAccessKey=QK+TiYdf1WJQJf5..........oczt1S634yI=  
```  

Your IOT HUB connection string value is stored in **.env** file with the following key: **iotHubConnString**   

Now continue running the following shell commands by replacing the placeholder <IOT_HUB_CONN_STR> in the below commands with IOT HUB connection string value mentioned above.

```shell
iotHubConnStr=<IOT_HUB_CONN_STR>
configFile=/etc/iotedge/config.yaml
sudo sed -i "s#\(device_connection_string: \).*#\1\'$iotHubConnStr\'#g" $configFile
sudo systemctl restart iotedge
```  

## 5.4. Restart the machine
Run the following command in the terminal window to the IoT Edge device:

```shell
sudo reboot
```
