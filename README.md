# HTML Analysis
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
* Enrich Docker-Compose Setup to proccess also a instance of MySql, to make the application run entirely local
* Implement a restricted admin section
* Performance improvements

## Notable Folders
* htmlanalysis/ClientApp railsjs application
* htmlanalysis/* .NETCore WebApi project
* htmlanalysis/Domain folder holdes (xml) documented classes with the domain
* htmlanalysis/Migrations holds EFCore Migrations

## Design Notes
* DDD approach for design
* SOLID principles properly applied
* Unit tests covering most important routines
* Naming attempted created valid domain ubiqutuous language
* Slice tests ensuring sucessfull partial integration between critical components
* API + SPA segregation
* UI / Backend communication using REST-like/SOA approach
* EntityFrameworkCore - CodeFirst - used for persistence
