# AddressBook
To run this application you need to locate in folder where "docker-compose.yml" file is located with your console and run commands:

docker-compose build

docker-compose up

Before you run "docker-compose up" make sure ports 8000 and 8001 are not in use.

This application exposes two routes:

http://localhost:8000/api/contact
http://localhost:8000/api/contact/{contactId}/number/

if you chose to run this without docker, database must be initiated from script in /db folder and webconfig must be adjusted to connect to created database
