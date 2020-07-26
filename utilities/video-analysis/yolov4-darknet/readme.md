# Yolov4 Darknet model

The following instructions will enable you to build a Docker container with Darknet [Yolov4](http://pjreddie.com/darknet/yolo/) model using [opencv](https://opencv.org/), [cpprestsdk](https://github.com/microsoft/cpprestsdk/).

Note: References to third-party software in this repo are for informational and convenience purposes only. Microsoft does not endorse nor provide rights for the third-party software. For more information on third-party software please see the links provided above.

## Contributions needed

* Production ready C++ REST API Server   
    - To consider: https://pocoproject.org, https://github.com/boostorg/beast



## Prerequisites

1. [Install Docker](http://docs.docker.com/docker-for-windows/install/) on your machine
2. Install [curl](http://curl.haxx.se/)
3. A sample JPEG image containing the objects you want to have detected

## Building the docker container

Ensure that [Docker is running on your machine.](https://docs.docker.com/docker-for-windows/install/#start-docker-desktop)

Navigate to the directory where you have cloned your repository.
Now, build the container image (should take some minutes) by running the following Docker command from a command window in that directory

```bash
    docker build . -t lvaextension:yolov4.v1
```

## Running and testing

Run the container using the following Docker command

```bash
    docker run --name my_container -p 8080:44000 -d -i lvaextension:yolov4.v1
```

Note that you can use any host port that is available instead of 8080.

Test the container using the following commands

### /score

To get a list of detected objects using the following command

```bash
   curl -X POST http://127.0.0.1:8080/score -H "Content-Type: image/jpeg" --data-binary @<image_file_in_jpeg>
```

If successful, you will see JSON printed on your screen that looks something like this

```JSON
{
    "inferences": [
        {
            "entity": {
                "box": {
                    "h": 0.3498992351271351,
                    "l": 0.027884870008988812,
                    "t": 0.6497463818662655,
                    "w": 0.212033897746693
                },
                "tag": {
                    "confidence": 0.9857677221298218,
                    "value": "person"
                }
            },
            "type": "entity"
        },
        {
            "entity": {
                "box": {
                    "h": 0.3593513820482337,
                    "l": 0.6868949751420454,
                    "t": 0.6334065123374417,
                    "w": 0.26539528586647726
                },
                "tag": {
                    "confidence": 0.9851594567298889,
                    "value": "person"
                }
            },
            "type": "entity"
        }
    ]
}
```

## Terminating

Terminate the container using the following docker commands

```bash
docker stop my_container
docker rm my_container
```

## Upload docker image to Azure container registry

Follow instruction in [Push and Pull Docker images  - Azure Container Registry](http://docs.microsoft.com/en-us/azure/container-registry/container-registry-get-started-docker-cli) to save your image for later use on another machine.

## Deploy as an Azure IoT Edge module

Follow instruction in [Deploy module from Azure portal](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-deploy-modules-portal) to deploy the container image as an IoT Edge module (use the IoT Edge module option).
