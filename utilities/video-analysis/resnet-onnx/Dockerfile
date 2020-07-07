# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.

FROM ubuntu:18.04

# Copy the app file and the tags file
RUN mkdir /app
COPY app/resnet-app.py /app
# COPY  tags.txt /app

# Install python
RUN apt-get update -y && \
    apt-get install -y --no-install-recommends python3-pip python3-dev && \
    cd /usr/local/bin && \
    ln -s /usr/bin/python3 python && \
    pip3 install --upgrade pip

# Install python packages
RUN pip install numpy onnxruntime flask pillow gunicorn requests && \
    apt-get clean

# Install runit, nginx
RUN apt-get update -y && \
    apt-get install --no-install-recommends -y wget runit nginx

# Install Nchan module. For details goto http://nchan.io
RUN apt-get update -y && \
    apt-get install -y libnginx-mod-nchan

# Download the model
RUN cd /app && \
    wget https://github.com/onnx/models/raw/master/vision/classification/synset.txt && \
    wget https://github.com/onnx/models/raw/master/vision/classification/resnet/model/resnet50-v2-7.tar.gz && \
    tar -xzf resnet50-v2-7.tar.gz && \
    rm -rf resnet50-v2-7.tar.gz && \
    rm -rf /var/lib/apt/lists/* && \
    apt-get clean && \
    apt-get purge -y --auto-remove wget

# Copy nginx config file
COPY resnet-app.conf /etc/nginx/sites-available

# Setup runit file for nginx and gunicorn
RUN mkdir /var/runit && \
    mkdir /var/runit/nginx && \
    /bin/bash -c "echo -e '"'#!/bin/bash\nexec nginx -g "daemon off;"\n'"' > /var/runit/nginx/run" && \
    chmod +x /var/runit/nginx/run && \
    ln -s /etc/nginx/sites-available/resnet-app.conf /etc/nginx/sites-enabled/ && \
    rm -rf /etc/nginx/sites-enabled/default && \
    mkdir /var/runit/gunicorn && \
    /bin/bash -c "echo -e '"'#!/bin/bash\nexec gunicorn -b 127.0.0.1:8000 --chdir /app resnet-app:app\n'"' > /var/runit/gunicorn/run" && \
    chmod +x /var/runit/gunicorn/run

EXPOSE 80

# Start runsvdir
CMD ["runsvdir","/var/runit"]