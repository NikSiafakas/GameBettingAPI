# Game Betting API

This project contains a REST API, implementing CRUD (Create-Read-Update-Delete) for Matches of different sports and their Odds.

It is developed using ASP.NET CORE 3.1, MS SQL Server, Entity Framework Core (code-first initial migration) and Swagger.


## Installation

You will need Visual Studio and an SQL Server.

Use git to clone the repository and open it with Visual Studio.

Modify the "GameBetSqlDbConnectionString" in the appsettings.json file to select a server (changing the 'my_server' value to your server name) and Build the solution.

Open the Package Manager Console, change the directory to '\GameBettingAPI' and execute 'dotnet ef database update' to create the database.

Then, Run the 'GameBettingAPI' and you should be seeing the Swagger UI:

![Swagger UI](.SwaggerUI.PNG)


## Usage

The Swagger UI will guide you through the functionality, providing example inputs whenever needed, as well as the URL for each endpoint.

Namely, the endpoint (in order):

* GET (read) all saved matches

* POST (create) a new match

* PUT (update) the existing match with the specified (match)id

* GET (read) the match with the specified (match)id

* DELETE the match with the specified (match)id (note that when a match is deleted, all related match odds will be automatically deleted as well)

* GET (read) all saved match odds

* POST (create) new match odds

* PUT (update) the existing match odds with the specified (odds)id

* GET (read) all saved match odds for the match with the specified (match)id

* GET (read) the match odds with the specified (odds)id

* DELETE the match odds with the specified (odds)id


## License

[MIT](https://choosealicense.com/licenses/mit/)

