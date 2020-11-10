# Mikro Case Study

MovieStoreApi it's working with message queue. I used ASP.NET Core Web API and EntityFrameworkCore,MediatR,Swagger,RabbitMQ Queue,BackgroundServices,Fluent Validation,AutoMapper 


## Getting Started

First of all, you need to clone the project to your local machine

```
git clone https://github.com/oyilmaaz/MovieStoreApi.git
cd mikro-case-study
```

### Building

A step by step series of building that project

1. Restore the project :hammer:

```
dotnet restore
```

2. Update appsettings.json or appsettings.Development.json (Which you are working stage)

2. Change all connections for your development or production stage

3. If you want to use different Database Provider (MS SQL, MySQL etc...) You can change on Data layer

```
    //For Microsoft SQL Server
    services.AddDbContext<MovieStoreContext>(options => options.UseSqlServer(connectionString, opt => opt.MigrationsAssembly("MovieStoreApi.Data")));
```

4. Run EF Core Migrations
```
dotnet ef database update
```

## Running

### Run with Dotnet CLI

1. Run API project :bomb:

```
dotnet run -p ./MovieStoreApi/MovieStoreApi.csproj
```
## Built With

* [.NET Core 3.1](https://www.microsoft.com/net/) 
* [Entitiy Framework Core](https://docs.microsoft.com/en-us/ef/core/) - .NET ORM Tool
* [SQLServer for EF Core](https://docs.microsoft.com/en-us/ef/core/) - SQLServer extension for EF 
* [Swagger](https://swagger.io/) - API developer tools for testing and documention
* [RabbitMQ](https://www.rabbitmq.com/dotnet.html) - API developer tools for creating message queues
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)


## Contributing

* If you want to contribute to codes, create pull request
* If you find any bugs or error, create an issue
