# Calorie Counter: Keep track of what you eat with completely free and open source software

# What is this? Why?
It is a personal project with the intention of demonstrating different programming practices both in the backend and in the frontend

- Use aspect oriented programming using interceptors.
- Test new project structure by dividing the bounded context from the beginning into separate folders.
- Test a new control inversion framework compatible with the current version of Net Core on this date.
- Test PBKDF2 for hashing passwords.
# Used technology
### Backend
- ASP NetCore 3.1 as main backend technology.
- Autofac as IoC container. Visit their project on Github https://github.com/autofac/Autofac
- CastleCore for interceptors and aspect oriented programming. Visit their project on Github https://github.com/castleproject/Core
- Fluent NHibernate for data persistence. Visit their project on Github https://github.com/FluentNHibernate/fluent-nhibernate
- NUnit for unit testing. Visit their project on Github https://github.com/nunit/nunit
- NLog for logging. Visit their project on Github https://github.com/NLog/NLog
### Frontend
- ASP NetCore 3.1
- React. Visit their project on Github https://github.com/facebook/react
- Bootstrap. Visit their project on Github https://github.com/twbs/bootstrap

# Project status
This project is in DEVELOPMENT.

# Coding guidelines
Intention is to follow Microsoft's dotnet best practices. Visit their dotnet/runtime project on Github. https://github.com/dotnet/runtime/blob/master/docs/coding-guidelines/coding-style.md

**Note:** Some things have been left in such a way that it might not seem like the most correct way to keep simplicity and demonstrate the above mentioned points.

# Instructions
1. Create the environment variable CALORIECOUNTER_DB and assign it the corresponding value to the postgres connection string. 
Example:
CALORIECOUNTER_DB = "Server=[server];Port=[port];Database=[database];User Id=[user];Password=[password];

2. Run the create_database.sql script on the database
