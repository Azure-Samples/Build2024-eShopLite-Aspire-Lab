# Get started building cloud native apps with .NET Aspire

.NET Aspire is an opinionated, cloud-ready stack to build observable, production-ready distributed applications. In this workshop we'll look at the role .NET Aspire plays in .NET cloud native development and build an app! Learn how to build a containerized frontend and backend applications with orchestration to help with composition and service discovery. See how to add in Azure Redis Cache and monitor all the moving parts with the Aspire dashboard. We'll also deploy it to Azure Container Apps. And if we have time, we'll add in a PostgreSQL database to the mix!

## Prerequisites

* .NET 8
* Visual Studio v17.10 (including any v17.10 Previews)
* .NET Aspire workload
* Docker Desktop
* Azure Developer CLI (`azd`)

[Full tooling and setup instructions](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling)

## What you'll learn

In this lab you will:

 * Learn how to add .NET Aspire to your .NET application and enable service discovery. 
 * Use Redis caching to increase performance of the application and discover how .NET Aspire makes it easy to access Redis caching services.
 * Deploy the entire application to Azure Container Apps (ACA) using the Azure Developer CLI (`azd`).
 * Optionally, add a database into a container to the application using .NET Aspire.

## Next

To get started, head over to the **[Labs](/Labs/README.md)** directory to get started on Lab 1 - Add Aspire and Service Discovery to an existing app!
