# moore-market

This project was build using [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio-code)

## Prerequisites

This project is assuming you have the following installed:

* [Visual Studio Code](https://code.visualstudio.com/)
* [.NET Core 2.2 SDK](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* [Node.js](https://nodejs.org/en/)
* [Vue CLI](https://cli.vuejs.org/)
* [Docker and Docker Compose](https://www.docker.com/get-started)

The backend rEST API is contained within the `/MooreMarket/` directory, and all the frontend assets are contained within the `/frontend/` directory.

## Installation

* Clone this repository
* When prompted by Visual Studio Code, install all the required extensions
* `cd` into the `/frontend/` directory and run `npm install`
* To startup the frontend SPA, run `npm run serve`
* To startup the database, run `docker-compose up -d`
* To run the backend rEST API, use the debugger and run the `.NET Core Launch (web)`