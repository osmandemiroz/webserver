# BIM308 - Web Server Programming

## Repository Structure

This repository contains assignments for the BIM308 Web Server Programming course.
Each assignment lives in its own folder: `bim308_hw1/`, `bim308_hw2/`, etc.
Assignment PDFs are placed alongside their project folders for reference.

## Tech Stack

- **Framework:** ASP.NET Core 8.0 MVC
- **Language:** C#
- **ORM:** Entity Framework Core (from HW2 onwards)
- **Database:** SQL Server
- **Frontend:** Razor Views, Bootstrap 5, Font Awesome
- **Containerization:** Docker

## Assignment Workflow

When a new assignment PDF is provided:

1. Create a folder named `bim308_hwN/` in the repo root
2. Place the project and PDF inside that folder
3. Review the PDF requirements against the current code
4. Generate a **GitHub-style checklist** comparing requirements vs. current state
5. Work through the checklist items to complete the assignment

## Review Checklist Format

When reviewing an assignment, generate a checklist in this format:

```
## BIM308 HW{N} - Review Checklist

### Section 1: {Section Name}
- [ ] Requirement description — STATUS: what's missing or wrong
- [x] Requirement description — STATUS: done

### Section 2: ...
```

Mark items `[x]` only when fully implemented and verified in code.
Mark items `[ ]` when missing, incomplete, or incorrect.
Add a brief status note after each item.

## Code Conventions

- Project namespaces use `BookLibraryEF` (not `BookLibrary`) for EF-based projects
- Models go in `Models/` folder
- DbContext goes in `Data/` folder
- Controllers go in `Controllers/` folder
- Views follow `Views/{ControllerName}/{ActionName}.cshtml`
- Use Code-First migrations for database creation
- Dockerfile must reference the correct DLL name (e.g., `BookLibraryEF.dll`)

## Build & Run

```bash
# From the project directory (e.g., bim308_hw2/BookLibraryEF/)
dotnet restore
dotnet build
dotnet run

# Docker
docker build -t booklibrary-ef .
docker run -p 8080:8080 booklibrary-ef
```

## Submission

- Format: `yourlastname_yourID_hwN.zip`
- Include `ReadMe.txt` with group member info
- Dockerfile is required for containerization
- Submit to ESTUOYS platform before deadline
