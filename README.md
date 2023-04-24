# Database Migrations Exercise

## Learning Objectives
- Use Entity Framework migrations to manage changes to table structures


## Instructions

1. Fork this repository
2. Clone your fork to your machine
3. Open the project in Visual Studio
4. I have restricted config from being uploaded to github (see the end of .gitignore)    
   What you need to do now is change the PizzaContext.cs file to use your ElephantSql instance.    
   If you Ctrl+c then  Ctrol+v on the App.config.fake file to create a duplicate of this.  Remove the extension    
   .fake so the file name is App.config    Now you can look at the connection string and replace each item with your own Elephant credentials.

5. In the Package Manager Console initiate the migraion:   PM>   Add-Migration InitialCreate

Build started...     
Build succeeded.     
To undo this action, use Remove-Migration.    

This should generate a Migrations folder with some c# to create the database.     


6. In the Package Manager Console update the database  :   PM>  Update-Database

Build started...     
Build succeeded.     
Applying migration '20230424151917_InitialCreate'.      
                                                       something like this should appear!


7.  Now make a change.



## FYI

If you are using VSCode you can install EF using:   $ dotnet tool install -g dotnet-ef

and run commands like this:  $ dotnet ef migrations add InitialCreate
                             $ dotnet ef database update    

from your console.