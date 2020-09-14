Library Management System POC
# Description
This project assumes that the end user is librarian and their task is to register the assigned book or returned book.
When *librarian* enters the page, he can see the list of books with their name and `Assign or Return` button next to it. He/she can chose the book and clicks on the button and he/she will be redirected to `assignbook` page. 
Based on the selection of the user, the `Assign To User` and `Return Book` button toggles. If a book is assigned to user, `Return Book` button appears, where as `Assign To User` in other case. When a book is assigned to user, the book count is decreased where as when a book is returned, book count increases. Only those books are shown, whose count is greater than zero. 

# Frontend
Frontend application is kept inside LibMS.Client. It is built with angular version[Angular CLI](https://github.com/angular/angular-cli) 10.
We have two page, one is the list of books and another assign/return page.
Current Backend Api is hosted at `http://localhost:61487/api`. In case the backend server url is changed, please change it in `api.service.ts`'s variable `SERVER_URL`.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.
 
# Backend
The api is created on .Net Core 3.1(https://dot.net). The Api project is named `LibMs.Api`. This project references LibMS.Service, LibMS.Entity, LibMS.Repository, LibMS.DataAccess for their consecutive layers. 
The dependency injection for different Services, and Repositories are maintained in Startup.cs. 
*Entity Framework Core* is used as ORM. 
*Test Driven Development* and *SOLID* Design pattern is followed.

# Unit Test
Xunit is used as testing framework where as Moq is for mocking data. `LibMSTest` is test project.

# Database 
Sql Database Project is kept in LibMS.Db. Queries with data is also kept inside SQLQueries Folder. Since, we currently don't have stored procedure, Database Unit Test project is not created.

# Things Left to do
Authentication implementation is not completed, where as the image upload for books were also not done. 

