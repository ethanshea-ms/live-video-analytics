
Lets list the modules running on our edge device:

run the command "sudo iotedge list" on the edge device.

```bash
mksa@mksa-NUC7i7BNHX:~$ sudo iotedge list
NAME             STATUS           DESCRIPTION      CONFIG
mediaEdge        running          Up 4 hours       marketplace.azurecr.io/<PART OF THIS HIDDEN FOR SECURITY REASONs...>linux-x64
mkov01aimodule   running          Up 5 hours       mkov01contreg.azurecr.io/mkov01aimodule:latest
edgeAgent        running          Up 5 hours       mcr.microsoft.com/azureiotedge-agent:1.0
edgeHub          running          Up 5 hours       mcr.microsoft.com/azureiotedge-hub:1.0
```

above output shows that 4 of the modules that we specified in the manifest file runs on the edge device since the last 4-5 hours... Seems all good but not yet...

Now check the logs of AI module to see any [ERROR]

```bash
mksa@mksa-NUC7i7BNHX:~$ clear && sudo iotedge logs mkov01aimodule --tail 1000
...

If you enable the debug mode with direct method invocation mentioned very below, or if you customize the score.py or app.py to add some debug details with logger.log(..) command, you should see these logs like:

...
{"timestamp": "2020-03-11T22:26:25.850485Z", "message": "[AI EXT] Received scoring request", "host": "26b857c7cd8a", "path": "/isserver/app.py", "tags": [], "level": "INFO", "logger": "AnalyticsAPILogger", "stack_info": null}
{"timestamp": "2020-03-11T22:26:25.917537Z", "message": "[AI EXT] Sending response.", "host": "26b857c7cd8a", "path": "/isserver/app.py", "tags": [], "level": "INFO", "logger": "AnalyticsAPILogger", "stack_info": null}
{"timestamp": "2020-03-11T22:26:25.917841Z", "message": "127.0.0.1 - - [11/Mar/2020 22:26:25] \"\u001b[37mPOST /score HTTP/1.0\u001b[0m\" 200 -", "host": "26b857c7cd8a", "path": "/opt/miniconda/lib/python3.7/site-packages/werkzeug/_internal.py", "tags": [], "level": "INFO", "logger": "werkzeug", "stack_info": null}
mksa@mksa-NUC7i7BNHX:~$ 
```

above timestamp field is in UTC time zone and seems that our AI module receives inference requests, and sending succesfull results. If needed, you can enable more extensive source code debugging and watch the logs here.

Now we will monitor the inference results. Out of many, here we will explore two methods to monitor the messages.

#### Option 1) Using Visual Studio Code to monitor analytics results flowing out from LVA:  

If you havent already, download the VSCode here: https://code.visualstudio.com/  

Once you have the VSCode, install the IoT Edge extension which will let us monitor LVA edge modules' messages. IoT Edge extension can be found here: https://marketplace.visualstudio.com/items?itemName=vsciot-vscode.azure-iot-edge  

Click on the three dots on:  
<img src="../../../../../../images/_openvino_img_03_004.jpg" width=400 alt="> Figure: monitorin 1."/>  

in the pop-up menu, click "Select IOT Hub" menu item:  
<img src="../../../../../../images/_openvino_img_03_005.jpg" width=400 alt="> Figure: monitorin 2."/>  

Select the subscription where the IoT Hub hosted:  
<img src="../../../../../../images/_openvino_img_03_006.jpg" width=400 alt="> Figure: monitorin 3."/>  

Select the IoT Hub from the list:  
<img src="../../../../../../images/_openvino_img_03_007.jpg" width=400 alt="> Figure: monitorin 4."/>  

Select the IoT Edge device that you created:  
<img src="../../../../../../images/_openvino_img_03_008.jpg" width=300 alt="> Figure: monitorin 5."/>  

Now right click on the edge device and start monitoring the messages, analytics module's outputs:  
<img src="../../../../../../images/_openvino_img_03_009.jpg" width=400 alt="> Figure: monitorin 6."/>  

"Output" window will open in VSCode. In that window you can monitor the result of the AI module's output in a live stream. Messages are in Json format (see section 1):  
<img src="../../../../../../images/_openvino_img_03_010.jpg" width=800 alt="> Figure: monitorin 7."/>  

In the above window, section 2, there is a stop button that you can use to stop monitoring... (or you can again right click on the edge device name and click stop monitoring)  

> <span style="color:red; font-weight: bold; font-size:1.1em;"> [!Important] </span>  
> Below we will continue with Option 2 of the monitoring task. While option 1 is active (meaning that while you are monitoring the messages in VS code, you cant stream the messages to Option 2. So you must stop monitoring here before continuing with Option 2.)  

#### Option 2: Monitoring through "Azure Time Series Insights" service:  
We will monitor messages and visualize the data with Azure Time Series Insights (ATSI) service.  

1) From the portal, create an ATSI service https://portal.azure.com (Details on how to create and more: https://docs.microsoft.com/en-us/azure/time-series-insights/)

2) Give a name and set related fields in ATSI Create window. Finally click on the "Next: Event Source" button (see 3 on the image below)  
<img src="../../../../../../images/_openvino_img_03_011.jpg" width=800 alt="> Figure: Azure Time Series Insights 1."/>  

3) Fill in the form by selecting existing IoT Hub (which you created before). Fill the rest of the fields and finally click create.  
<img src="../../../../../../images/_openvino_img_03_012.jpg" width=800 alt="> Figure: Azure Time Series Insights 2."/>  

4) Click the link to open the explorer UI:  
<img src="../../../../../../images/_openvino_img_03_013.jpg" width=800 alt="> Figure: Azure Time Series Insights 3."/>  


Referring to inference result which is in JSon file format, we have:
```json
{
   "status": 0,
   "time": 45.6475,
   "object_count": 100,
   "result": {
      "0": {
         "label": 1,
         "confidence": 1,
         "xmin": 304,
         "ymin": 169,
         "xmax": 398,
         "ymax": 436
      },
      "1": {
         "label": 2,
         "confidence": 0.99,
         "xmin": 474,
         "ymin": 201,
         "xmax": 586,
         "ymax": 485
      },

        ...

      "100": {
         "label": 5,
         "confidence": 0.53,
         "xmin": 385,
         "ymin": 140,
         "xmax": 421,
         "ymax": 246
      }
   }
}
```

Based on above output fields, we can filter out specific object types (classes like view just cars, people, bicycles etc.), we can visualize specific timer range or view message details. Below some screenshots from ATSI:

1) Initial ATSI window. Select time range to monitor the events.  
<img src="../../../../../../images/_openvino_img_03_014.jpg" width=800 alt="> Figure: Azure Time Series Insights 4."/>  

2) Select time range (1: refresh chart, 2: select time 3: apply and search time range)  
<img src="../../../../../../images/_openvino_img_03_015.jpg" width=800 alt="> Figure: Azure Time Series Insights 5."/>  

3) Visualize the event counts. This chart looks straigth line. Because it continuously analyse 2 fps and generates 2 messages per second. So the count of the event is static. If there is a drop, gap etc. means that it couldnt ingest data from camera.  
<img src="../../../../../../images/_openvino_img_03_016.jpg" width=800 alt="> Figure: Azure Time Series Insights 6."/>  

4) View the analytic module's output, json messages in a table format:  
<img src="../../../../../../images/_openvino_img_03_017.jpg" width=800 alt="> Figure: Azure Time Series Insights 7."/>  
<img src="../../../../../../images/_openvino_img_03_018.jpg" width=800 alt="> Figure: Azure Time Series Insights 8."/>  

5) Now add number of objects (vehicle, person, etc.) detected in the video stream over time.  
<img src="../../../../../../images/_openvino_img_03_019.jpg" width=800 alt="> Figure: Azure Time Series Insights 9."/>  

6) Visualize detected object count as a heat map. First remove the event count and just keep the orange (object count) chart. Finally switch to Heat map visualization tab.  
<img src="../../../../../../images/_openvino_img_03_020.jpg" width=800 alt="> Figure: Azure Time Series Insights 10."/>  

#### Update the Analytics module (ML Solution) parameters in runtime through cloud
As reference sample, we add few settings over the edge device AI module that you can update at anytime while the module is running.  

Referring to the "app.py" code in our ML solution folder, we have following parameters that you can set:

```python
            if methodRequest.name == "SetProbabilityThreshold":
                analyticsAPI.setProbabilityThreshold(float(methodRequest.payload))
                callResult = str(analyticsAPI.getProbabilityThreshold())

            elif methodRequest.name == "SetModel":
                analyticsAPI.setModelName(str(methodRequest.payload))
                callResult = analyticsAPI.getModelName()

            elif methodRequest.name == "SetModelPrecision":
                analyticsAPI.setModelPrecision(str(methodRequest.payload))
                callResult = analyticsAPI.getModelPrecision()

            elif methodRequest.name == "SetTargetDevice":
                analyticsAPI.setTargetDevice(str(methodRequest.payload))
                callResult = analyticsAPI.getTargetDevice()

            elif methodRequest.name == "SetDebug":
                IS_DEBUG = bool(methodRequest.payload)
                callResult = str(IS_DEBUG)

```

If you want to reduce the detection threshold (i.e. only detect object with confidence score bigger than 0.5) you can follow these steps:
1) Through the VSCode (also many other methods exist), right click on the edge device name in "IoT Hub" window.

2) on the pop-up menu, click on the "Invoke Device Direct Method" menu item.  
<img src="../../../../../../images/_openvino_img_03_021.jpg" width=400 alt="> Figure: Invoke Device Direct Method 1."/>  

3) On top of the VSCode window, there will be an input window that you can type any of the above method names. Here we type "SetProbabilityThreshold" (without quotes) and press ENTER  
<img src="../../../../../../images/_openvino_img_03_022.jpg" width=600 alt="> Figure: Invoke Device Direct Method 2."/>  

4) Now in the same window, enter value. We type i.e. 0.5 and press ENTER.  
<img src="../../../../../../images/_openvino_img_03_023.jpg" width=600 alt="> Figure: Invoke Device Direct Method 3."/>  

5) Now you can visualize the result of this method call in the Output window (or in the module logs as mentioned in previous steps)  
<img src="../../../../../../images/_openvino_img_03_024.jpg" width=600 alt="> Figure: Invoke Device Direct Method 4."/>  


#### Debugging
It is possible to set the debug flag by "Invoke Device Direct Method" by calling "SetDebug" method. It takes int value : 0: no debug, 1: log debug details and write video frame into host debug dir in case object detected 2: same as 1 but here no condition of detecting an object.  

Once the flag is set, it will output processed camera frames in the host computer's (edge device's) storage. Since we set this folder to be "/tmp/IS_DEBUG", you can look in that folder to see the debug outputs as jpeg images. 

<img src="../../../../../../images/_openvino_s1.jpg" width=800 alt="> Figure: Sample frame 1."/>  
<img src="../../../../../../images/_openvino_s2.jpg" width=800 alt="> Figure: Sample frame 2."/>  
<img src="../../../../../../images/_openvino_s3.jpg" width=800 alt="> Figure: Sample frame 3."/>  


#### Daily Debug Preview
By installing ffmpeg tool on your edge device
```shell
sudo apt-get install -y ffmpeg
```
you can create a daily fast forward snapshot video of the day and than delete the existing debug output files by using following shell commands:

```shell
FILTER=2020-03-17
VERSION=v1

sudo ffmpeg -framerate 100 -pattern_type glob -i "$FILTER*.jpg" -vcodec libx264 -crf 25  -pix_fmt yuv420p ~/Desktop/$FILTER-$VERSION.avi

for i in $FILTER*.jpg; do sudo rm "$i"; done
```

Since the size of the debug files (*.jpg) may reach to thousands, simple "rm -rf *.jpg" command will not work for large amount of files. That is the reason we are using rm in a loop.


#### Changing compute target
As this sample uses OpenVINO™, we can change the compute target to any available target we want. You can use "SetTargetDevice" direct method to change the compute target to any of the following:  
CPU : Intel CPU  
GPU : Intel GPU  
MYRIAD: Intel VPU  
FPGA: Intel FPGA  

When you change the compute target, you must take care about the precision setting. Each ML model have different precision compilations like FP16, FP32, FP16-INT8 etc. Some accelerators like VPU only supports FP16. So if you keep the precision as FP32 and change the accelerator to VPU, than it will not run.

Here is the reference that you can use to see the compute target capabilities:
https://docs.openvinotoolkit.org/latest/_docs_IE_DG_supported_plugins_Supported_Devices.html  

