# Simple Blazor Server
Simple Blazor Server application with Mediator
## Purpose
This is a .NET Core Template for spinning up a Blazor Server application quickly.
This project is generic, minimal and uses popular .NET libraries.
## Installation
Clone the repo and run the following command
```
dotnet new -i [absolute-path-to-root]
```
Alternatively you can navigate to the root folder and run
```
dotnet new -i .\
```
To create a project with the template run
```
dotnet new simpleblazorserver -n [name-of-project]
```
Please see this [blog](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates) post for more information on custom .NET Core Templates
## Removing
If you would like to remove the template run
```
dotnet new -u [absolute-path-to-root]
```
The path here must be absolute. There is no support for relative paths when removing a template.
## Technologies
- [MediatR](https://github.com/jbogard/MediatR)
- [AutoMapper](https://github.com/AutoMapper/AutoMapper)
- [FluentValidation](https://github.com/FluentValidation/FluentValidation)
- [.NET Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
- [Blazorise](https://github.com/stsrki/Blazorise)
