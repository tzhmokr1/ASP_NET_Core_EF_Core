#! /bin/bash

docker image build -t pg-ch5-image .
# make sure to clear port 5432 or change to different port
# use another name if you need to
docker container run --name pg-ch5 -d -p 5435:5432 pg-ch5-image