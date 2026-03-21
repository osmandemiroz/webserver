# Claude Review - BIM308 HW2: Entity Framework Core

> **Status:** IMPLEMENTATION COMPLETE (migration pending)
> **Reviewed:** 2026-03-21
> **Deadline:** 2026-03-29 23:59
> **Project:** `BookLibraryEF/`

## 1. Creating the Project
- [x] ASP.NET Core Web App (MVC) project created
- [x] Project named **BookLibraryEF**
- [x] NuGet: `Microsoft.EntityFrameworkCore` (8.0.2)
- [x] NuGet: `Microsoft.EntityFrameworkCore.SqlServer` (8.0.2)
- [x] NuGet: `Microsoft.EntityFrameworkCore.Tools` (8.0.2)
- [x] SQL Server connection string in `appsettings.json`

## 2. Creating the Models
- [x] **Author** class created (`Models/Author.cs`)
  - [x] `AuthorID` (int)
  - [x] `AuthorName` (string)
  - [x] `AuthorInfo` (string)
  - [x] Navigation Property: `ICollection<Book> Books`
  - [x] Relationship: One Author -> Many Books
- [x] **User** class created (`Models/User.cs`)
  - [x] `UserID` (int)
  - [x] `Name` (string)
  - [x] `Email` (string)
  - [x] Navigation Property: `ICollection<Book> Books`
  - [x] Relationship: Many Users <-> Many Books
- [x] **Book** class created (`Models/Book.cs`)
  - [x] `BookID` (int)
  - [x] `Title` (string)
  - [x] `ReleaseYear` (int)
  - [x] `Price` (double)
  - [x] `ImageUrl` (string)
  - [x] Foreign Key: `AuthorID`
  - [x] Navigation: `Author`
  - [x] Navigation: `ICollection<User> Users`

## 3. Creating the DbContext
- [x] `Data/LibraryContext.cs` created
- [x] Inherits from `DbContext`
- [x] `DbSet<Book> Books`
- [x] `DbSet<Author> Authors`
- [x] `DbSet<User> Users`
- [x] `OnModelCreating()` configures relationships
- [x] One-to-Many (Author -> Books) configured
- [x] Many-to-Many (Users <-> Books) configured via join table `BookUser`

## 4. Database Creation (Code-First)
- [x] Seed data included (6 authors, 6 books, 2 users)
- [ ] `Add-Migration InitialCreate` — **requires dotnet CLI**
- [ ] `Update-Database` — **requires dotnet CLI + SQL Server**

> Run these commands from `bim308_hw2/BookLibraryEF/`:
> ```
> dotnet ef migrations add InitialCreate
> dotnet ef database update
> ```

## 5. Creating the Controller
- [x] `LibraryController` created with DI-injected `LibraryContext`
- [x] **Index** — lists books with `Include(b => b.Author)` EF query
- [x] **AddBook** (GET) — shows form with author dropdown
- [x] **AddBook** (POST) — saves book to database
- [x] **AddUser** (GET) — shows form for name/email
- [x] **AddUser** (POST) — saves user to database
- [x] **RentBook** (GET) — shows user/book dropdowns
- [x] **RentBook** (POST) — creates many-to-many relationship

## 6. Creating the Views
- [x] `Views/Library/Index.cshtml` — displays books with author info
- [x] `Views/Library/AddBook.cshtml` — form with author select dropdown
- [x] `Views/Library/AddUser.cshtml` — form with name and email fields
- [x] `Views/Library/RentBook.cshtml` — user/book dropdowns with success message
- [x] Razor syntax used throughout
- [x] Each book displays its author information

## 7. Routing
- [x] Default MVC routing (`{controller=Home}/{action=Index}/{id?}`)
- [x] Navbar links to Library, AddBook, AddUser, RentBook

## 8. Submission Requirements
- [x] Dockerfile with `BookLibraryEF.dll` entrypoint
- [x] `ReadMe.txt` with group member info
- [x] All namespaces updated to `BookLibraryEF`

---

**Result: 34/36 requirements met** (2 pending: EF migration commands require dotnet CLI)
