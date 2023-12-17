# Ventures Lab Back-end challenge
Welcome to MoorCodeSofia Web API
# The Application
Build an application to manage a user's tasks.

- Create, delete and edit a task
- List of today's and upcoming tasks, grouped by date and time

Task must contain the data below:

- User
- Date
- Start and end time
- Subject
- Description
- 
# About The Project
The project contains a REST API called MoorCodeSofiaApi. 

# Interface

UserTask <br>
__POST /api/userTasks/create__ add a user tasks.<br>
__GET  /api/userTasks/getAllTasks__ get all user tasks.<br>
__GET  /api/userTasks/getTasksById{id:guid}__ get a detail of a user task.<br>
__POST /api/userTasks/updateTask__ update a user task.<br>
__POST /api/userTasks/deleteTask__ remove a user task.<br>

# Technologies
-	.NET 7.0 
-	ASP.NET Core Web API.  
-	Swagger Open API v3.1, 
-	CQRS with MediatR 
-	Fluent Validation 
-	AutoMapper
-	AutoFixture
-	Mock
-	Xunit
-	FluentAssertion

# Architecture
-	Clean Architecture
-	Full architecture with responsibility separation of concerns
-	Repository pattern

# Structure of solution
Repository include layers divided by 5 project;

*	Domain
    *	Entities
    *	Contracts
*	Application
    *	Interfaces
    *	Abstractions
    *	Behaviuors
    *	Models
    *	Mapping
    *	Commands
    *	Queries
    *	Handlers 
*	Infrastructure
    * Repositories
    *	EF Db Context	
*	WebAPI
    *	Controllers 
    *	Convfiguration
    *	DI      
*	UnitTesting
    *	Commands
    *	Queries
