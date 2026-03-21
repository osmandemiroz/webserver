# BIM308 - Web Server Programming

ASP.NET Core MVC assignments repository.

## Repository Structure

```
webserverprogramming/
  bim308_hw1/          # HW1 - MVC Basics
    BookLibrary/
    BIM308_HW1.pdf
    REVIEW.md
  bim308_hw2/          # HW2 - Entity Framework Core
    BookLibraryEF/
    BIM308_HW2.pdf
    REVIEW.md
```

---

## Claude Review

Each assignment is reviewed against its PDF requirements. Click an assignment below to see the full checklist.

| Assignment | Topic | Status | Score | Review |
|:--|:--|:--|:--|:--|
| [HW1](bim308_hw1/) | ASP.NET Core MVC Basics | Completed | 24/24 | [Review](bim308_hw1/REVIEW.md) |
| [HW2](bim308_hw2/) | Entity Framework Core | Implementation Complete | 34/36 | [Review](bim308_hw2/REVIEW.md) |

### HW1 - ASP.NET Core MVC Basics

- [x] Project setup (BookLibrary, .NET 8.0)
- [x] Book model with all required properties
- [x] LibraryController with Index action and 6 sample books
- [x] Razor View with image, rating, and price display
- [x] Default MVC routing works
- [x] Dockerfile included

### HW2 - Entity Framework Core

- [x] EF Core packages installed (Core, SqlServer, Tools)
- [x] Author model (One-to-Many with Book)
- [x] User model (Many-to-Many with Book)
- [x] Book model with FK and navigation properties
- [x] LibraryContext DbContext with seed data
- [x] LibraryController: Index, AddBook, AddUser, RentBook
- [x] Four Razor views with forms and data display
- [x] Dockerfile updated to BookLibraryEF.dll
- [ ] EF Migration (requires `dotnet ef` CLI)
- [ ] Database update (requires SQL Server)
