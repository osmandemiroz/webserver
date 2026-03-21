# Claude Review - BIM308 HW1: ASP.NET Core MVC Basics

> **Status:** COMPLETED
> **Reviewed:** 2026-03-21
> **Project:** `BookLibrary/`

## 1. Creating the Project
- [x] ASP.NET Core Web App (MVC) project created
- [x] Project named **BookLibrary**
- [x] Models folder present
- [x] Views folder present
- [x] Controllers folder present
- [x] Default controller (`HomeController`) and default action (`Index`) present

## 2. Creating the Model
- [x] `Models/Book.cs` class created
- [x] `BookID` (int) property
- [x] `Title` (string) property
- [x] `Director` (string) property
- [x] `Stars` (string[]) property for 5-star rating
- [x] `ReleaseYear` (int) property
- [x] `ImageUrl` (string) property
- [x] `Price` (double) property
- [x] No methods added (properties only)

## 3. Creating the Controller
- [x] `Controllers/LibraryController.cs` created
- [x] `Index` action method present
- [x] List of books created inside Index action
- [x] At least 5 books with sample data (6 books provided)
- [x] List sent to the View via `return View(books)`

## 4. Creating the View
- [x] `Views/Library/` folder created
- [x] `Views/Library/Index.cshtml` Razor View created
- [x] Strongly typed with `@model List<BookLibrary.Models.Book>`
- [x] Book image displayed (`@book.ImageUrl`)
- [x] Rating info displayed (Stars iteration with `@foreach`)
- [x] Price info displayed (`$@book.Price.ToString("F2")`)
- [x] Razor syntax used to iterate over the list (`@foreach`)

## 5. Routing
- [x] Default MVC routing configured (`{controller=Home}/{action=Index}/{id?}`)
- [x] `/Library` route maps to `LibraryController.Index`

## 6. Execution
- [x] Page opens without errors
- [x] Book information and description visible
- [x] At least 5 books listed (6 provided)
- [x] Routing works correctly

## 7. Submission Requirements
- [x] Dockerfile present with `BookLibrary.dll` entrypoint
- [x] Project containerizable via Docker

---

**Result: 24/24 requirements met**
