# Blog Engine
Zemoga blog engine application

# Published application
BlogEngine application has been already deployed, you can access it through the next URL:
https://blog-engine-fe.azurewebsites.net

There are two user availables, which are:

	User: shakespeare@yahoo.com
	Password: 123456
	Role: writer

	User: perkins@gmail.com
	Password: 123456
	Role: editor
	
Note: Some information has been preloaded. Such as:
- Blogs in creation
- Blogs pending to check
- Blogs rejected
- Blogs approved


# Getting Started
Whether you want to execute the application locally. Please follow the next steps:

Database:
1. Prerequisite: Sql server 2019 or superior
2. On SSMS (Sql server management studio)
    - Execute scripts accord enum located in './database-scripts\schema'
    - Execute scripts accord enum located in './database-scripts\data'

Backend:
1. Prerequisite: Framework .NET CORE 5.0
2. On visual studio 2019 or superior
    - Open the solution 'ZemogaBlogEngine.sln' located in back-end folder
    - Change the connection string information accord to your database credentials in './DataAccess/CommonDA.cs'
    - Check and adjust CORS configuration whether is nedded
    - Make sure that your startup project in the solution is "WebApplication"
    - Build the solution (through ctrl + shit + b)
    - Execute the solution (through F5)

Frontend:
1. Prerequisite: NodeJS 14.15.4
2. On visual studio code
    - Open the front-end application located in './front-end'
    - Check and adjust the value of the parameter 'blogEngineWS' accord to your needs, in './src/environments' file. The value must contain the URL of the back end application.
3. On project folder './front-end' open power shell
    - Execute 'npm install' to install the packages needed for the front-end application
    - In order to run the application execute 'npm run start'


# Effort
Total hours to complete the test: 24


