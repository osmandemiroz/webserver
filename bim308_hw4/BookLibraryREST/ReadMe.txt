BIM308 - Web Server Programming - HW4

Group Members:
--------------
1. Osman Demiroz -
2. Mert Can Kalinlioglu -

Project: BookLibraryREST
------------------------
This project is an ASP.NET Core 8 RESTful API for the book library system.
It supports JSON-based CRUD operations for authors, books, and users.
Users can also rent and return books through REST endpoints.

Main Endpoints:
---------------
- GET    /api/authors
- GET    /api/authors/{id}
- POST   /api/authors
- PUT    /api/authors/{id}
- DELETE /api/authors/{id}
- GET    /api/books
- GET    /api/books/{id}
- POST   /api/books
- PUT    /api/books/{id}
- DELETE /api/books/{id}
- GET    /api/users
- GET    /api/users/{id}
- POST   /api/users
- PUT    /api/users/{id}
- DELETE /api/users/{id}
- POST   /api/users/{userId}/rent/{bookId}
- POST   /api/users/{userId}/return/{bookId}

How to Run:
-----------
1. Restore packages: dotnet restore
2. Build project: dotnet build
3. Run project: dotnet run
4. Open http://localhost:5088/api/books

Docker:
-------
1. Build: docker build -t booklibrary-rest .
2. Run: docker run -p 8080:8080 booklibrary-rest
3. Open http://localhost:8080/api/books
