# SampleProject

This project is a sample application demonstrating the usage of ASP.NET Web API, ASP.NET MVC, and a Console App. It also includes two class library projects called Services and Models.

## Prerequisites

- .NET 7 SDK
- Visual Studio 2022 (or any compatible code editor)

## Getting Started

1. Clone the repository to your local machine.
2. Open the solution file (`SampleProject.sln`) in Visual Studio.
3. Build the solution to restore NuGet packages and compile the projects.

## Project Structure

The solution consists of the following projects:

- **SampleProject.API**: Contains the ASP.NET Web API controllers and related configuration files.
- **SampleProject.Web**: Contains the ASP.NET MVC controllers, views, and related configuration files.
- **SampleProject.Test**: Contains a console application for interacting with the services.
- **SampleProject.Services**: A class library project that provides various services and business logic.
- **SampleProject.Models**: A class library project that defines the data models used across the solution.

## Running the Application

1. Set the desired startup project (e.g., ProjectName.Api, ProjectName.Mvc, or ProjectName.ConsoleApp) in Visual Studio.
2. Press F5 or click the Run button to start the application.

## API Endpoints

- **GET /api/Product/categories**: Retrieves a list of categories.
- **GET /api/Product/category/{category}**: Retrieves a specific products by category name.

## MVC Views and Controllers

The MVC project provides a user interface to interact with the services. It includes the following views and controllers:

- **HomeController**: Handles product-related actions and index.cshtml view.

## Console App

The console application demonstrates the usage of services in a non-web environment. It includes examples of invoking various service methods and displaying the results.