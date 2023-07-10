# LogispinWalletService

This services was developed using clean architecure. Command Query Responsibility Segregation Patter was used for the creation of this service. This service has been created to cater for the following requirements:

● Create a wallet

● Add funds to a wallet.

● Remove funds from a wallet.

● Query the current state of a wallet.

● The balance of a wallet cannot be negative.

● A user can’t spend the same funds twice.

● The client should interact with service with REST APIs.


### The Service contains the following Projects:

● LogispinWalletService: - This is a .NetCore Web API service which handles the interface for client communication with the service.

● LogispinWalletService.BL: - This is a class Library project that handles the Business Logic(BL) of the services implementation. Commands, queries as well as request and response objects are found here.

● LogispinWalletService.Common: - This is a class library project that houses common objects used across the enter service ecosystem. Enums, helper classes and methods as well as static constant variables are found here.

● LogispinWalletService.DAL: - This is a class library project that serves as the Data Access Layer (DAL) of the project. It is the go-between between the Businss Logic Layer and the Data Layer. The repositories are found here.

● LogispinWalletService.Data: This is a class library project that serves as the Data Layer. Models, DBContexts, migrations are found here. The connection to the Database is through EntityFrameworkCore.

● LogspinWalletService.Tests: This is a class library project that is houses test for the service.

## Instructions for Setup
The service uses Hangfire for its worker service needs, utilizing the fire and forget queing implementation to return the request thread quickly back with a response letting Hangfire handle the logic. To this end, in the DB which the service would be connecting to, Create a DB manually with the name 'HangfireDB' as depicted in the appsettings.development.json. When the service is run, HangfireDB would be populated with tables and storedprocedures which handle the jobs.

## Monitoring
Hangfire provides a dashboard for monitoring the jobs which runs on the service. This can be accessed by navigating to the url 'https://localhost:[port number]/hangfire' when the service is up and running
