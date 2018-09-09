# Code challenge
This is a web application created to process a website's words frequency

## Access deployed version
Deployed in Azure Platform with Google Cloud Database Platform it can be access through the url:

http://html-analysis.azurewebsites.net/

## Run locally:
As pre-requisites you will need git and docker up and running, then type:
```
git clone https://github.com/william-mendes/html-analysis.git
cd html-analysis
docker-compose up --build
```
Once the container is up and running go to: http://localhost:5000


## TODO
* Finish implementation of Stanford NLP to get only nouns and verbs
* Clean Html properties from words list
* Enrich DockerFile to proccess also a instance of MySql, to make the application run entirely local
* Implement a restricted admin section
* Performance improvements


## Notes
* Implementation of a SPA single page has been used for this project and front-end and back-end has been separated from each other using ReactJs in the front and AspNetCore 2.1 in the back-end
* To walk throughth the code, take a step into the Domain layer you will find all interfaces well documented explaning the projects process and goal
* It has been taken a code-first approach for the database structure and related migrations can be found at the Migrations folder
