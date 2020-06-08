follow sections:
01
02
03
04 (telling that in case user dont have physical device and want to us a VM for just testing the samples)

Per sample requirement (i.e. some samples may require CPU or GPU), we will guide here to follow 05 or 06...

before going with section 7, here specific to this sample, we will guide how to build a local docker image of the inference server with the AI logic (i.e. yolov3 object detection) specific to this sample. So at this point we have sample specific instructions to create the YoloV3 that runs on GPU... (earlier instrcutions are at https://github.com/mustafakasap/aix/tree/jupyternotebook_httpextension_nGPU_yolov3 )
complete this sample specific instructions under "yolov3-ngpu-onnx" folder, run notebooks 01, 02 and 03 under this folder to build a local container and test the container.


Once the user build local docker image for this sample and follow the local test instructions, he/she will continue with section 07
07

08 setup deployment manifest 
    - May include RTSP simulator (in cased dont have IP cam) If this is the case, than which sample video file should be played as virtual IP cam content? how these files to be copied into edge device. here we should guide accordingly
    - how inference server or any other (like LVA) module deployment settings are set.

09 deploy media graph

10 Check if all modules works fine, if we get inference results