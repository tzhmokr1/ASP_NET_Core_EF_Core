docker image build -t mariadb-lean-image:v6 .
#run container from generated image
docker container run -d --name maria-ch6 -p 3310:3306 mariadb-lean-image:v6

