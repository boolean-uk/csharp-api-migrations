using csharp_api_migrations.Main.Models;

Course computing = new Course();
computing.Title = "C# Software Development";
computing.Lecturer = new Lecturer() { Firstname = "Nigel", Lastname = "Sibbert", DOB = new DateTime(1975, 3, 1) };
computing.Students