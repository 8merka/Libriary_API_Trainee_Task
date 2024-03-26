# Libriary_API_Trainee_Task
This is a API to provide information about books
## Before first run

You should go to the Library.API/Extensions/ServiceConfiguration.cs and find method AddIdentityDbContext. Here you must find properity Password=PasswordThatYouNeed and chage PasswordThatYouNeed on your password from postgresql.

### Update Database using Migrations:
through .NET CLI:

    dotnet ef database update

through Package Manager:

    Update-Database

### After all of that you should press on a run button, which is usually located near ceter at the top of Visual Studio and look like a triangle filled with green and abbreviation "https" near it.

## Techologies 

THis project was developed using ASP.NET.CORE and PostgeSQL with Entity Framework 

## Architecture

The project was developed according to NTier Architecture principles
