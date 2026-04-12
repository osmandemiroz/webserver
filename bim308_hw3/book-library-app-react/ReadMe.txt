BIM308 - Web Server Programming - HW3

Group Members:
--------------
1. Osman Demiroz -
2. Mert Can Kalinlioglu -

Project: Book Library App (React)
----------------------------------
This is a React-based frontend application for a library system.
It fetches data from JSON files and supports:
- Viewing all books with author names, prices, and images
- Viewing all users with their rented book names
- Renting a book to a user

How to Run:
-----------
1. Install dependencies: npm install
2. Start development server: npm start
3. Open http://localhost:3000 in your browser

Docker:
-------
1. Build: docker build -t book-library-react .
2. Run: docker run -p 8080:8080 book-library-react
3. Open http://localhost:8080 in your browser
