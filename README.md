`student_api` is a sample project built with C# and ASP.NET using the `dotnet new webapi` template.  The project interfaces with a front-end client written in React.  That project can be found [here](https://github.com/snsavage/students_client).


To set up the project for local development, run the following commands.  These will add required packages and run the database migrations.

```
$ dotnet restore
$ dotnet ef database update
```

To start a local development server run the following.

```
$ dotnet watch run
```
