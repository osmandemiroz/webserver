## BIM308 HW4 - Review Checklist

### Section 1: Project Setup
- [x] Create `bim308_hw4/` folder - STATUS: done; HW4 folder exists in the repository root.
- [x] Place assignment PDF inside HW4 folder - STATUS: done; PDF moved to `bim308_hw4/BIM308_HW4.pdf`.
- [x] Create `BookLibraryREST` project - STATUS: done; ASP.NET Core 8 Web API project files are under `bim308_hw4/BookLibraryREST/`.
- [x] Target .NET 8.0 - STATUS: done; `BookLibraryREST.csproj` targets `net8.0`.

### Section 2: Data Models
- [x] Author model with `authorID`, `authorName`, `authorInfo` - STATUS: done; implemented in `Models/Author.cs` with JSON field names.
- [x] Book model with `bookID`, `title`, `releaseYear`, `price`, `authorID` - STATUS: done; implemented in `Models/Book.cs`.
- [x] User model with `userID`, `name`, `email`, `rentedBookIDs` - STATUS: done; implemented in `Models/User.cs`.
- [x] Book-author relationship - STATUS: done; books carry `AuthorID` and service validation prevents invalid author references.
- [x] User-book rental relationship - STATUS: done; users store rented book IDs and rent/return operations update them.

### Section 3: Layered Architecture
- [x] Controller layer - STATUS: done; separate API controllers exist for authors, books, and users.
- [x] Service layer - STATUS: done; `ILibraryService` and `LibraryService` contain validation and use-case logic.
- [x] Repository layer - STATUS: done; `ILibraryRepository` and `InMemoryLibraryRepository` manage seeded in-memory data.
- [x] Sample data - STATUS: done; seed authors, books, and users are provided in `Data/SeedData.cs`.
- [x] Dependency injection - STATUS: done; service and repository are registered in `Program.cs`.

### Section 4: Author REST API
- [x] List all authors with `GET /api/authors` - STATUS: done.
- [x] Get author with `GET /api/authors/{id}` - STATUS: done; returns `404` when missing.
- [x] Add author with `POST /api/authors` - STATUS: done; returns `201 Created`.
- [x] Update author with `PUT /api/authors/{id}` - STATUS: done; returns `204 No Content` on success.
- [x] Delete author with `DELETE /api/authors/{id}` - STATUS: done; prevents deleting authors still referenced by books.

### Section 5: Book REST API
- [x] List all books with `GET /api/books` - STATUS: done.
- [x] Get book with `GET /api/books/{id}` - STATUS: done; returns `404` when missing.
- [x] Add book with `POST /api/books` - STATUS: done; validates that `authorID` exists.
- [x] Update book with `PUT /api/books/{id}` - STATUS: done; validates route/body ID and author reference.
- [x] Delete book with `DELETE /api/books/{id}` - STATUS: done; also removes the deleted book from user rental lists.

### Section 6: User REST API
- [x] List all users with `GET /api/users` - STATUS: done.
- [x] Get user with `GET /api/users/{id}` - STATUS: done; returns `404` when missing.
- [x] Add user with `POST /api/users` - STATUS: done; validates rented book IDs.
- [x] Update user with `PUT /api/users/{id}` - STATUS: done; validates route/body ID and rented book IDs.
- [x] Delete user with `DELETE /api/users/{id}` - STATUS: done.
- [x] Rent a book with `POST /api/users/{userId}/rent/{bookId}` - STATUS: done; prevents duplicate rentals.
- [x] Return a book with `POST /api/users/{userId}/return/{bookId}` - STATUS: done; validates that the user currently has the book.

### Section 7: REST and JSON Requirements
- [x] RESTful API principles - STATUS: done; resources are grouped under `/api/authors`, `/api/books`, and `/api/users`.
- [x] Proper HTTP status codes - STATUS: done; controllers return `200`, `201`, `204`, `400`, and `404` as appropriate.
- [x] JSON request/response format - STATUS: done; controllers are `[ApiController]` endpoints and models use explicit `JsonPropertyName` attributes.
- [x] Validation for invalid IDs and relationships - STATUS: done; service returns bad request or not found results before mutating data.

### Section 8: Deployment and Submission
- [x] Dockerfile included - STATUS: done; multi-stage Dockerfile builds and runs the API.
- [x] Dockerfile runs `BookLibraryREST.dll` - STATUS: done; entrypoint is `dotnet BookLibraryREST.dll`.
- [x] Docker exposes port `8080` - STATUS: done.
- [x] `ReadMe.txt` included - STATUS: done; group member placeholders, endpoints, local run, and Docker instructions are documented.
- [x] Local checklist verification - STATUS: done; `.github/scripts/review-hw.sh 4` passes `64/64` checks.
