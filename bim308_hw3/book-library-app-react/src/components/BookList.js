import React, { useEffect, useState } from 'react';
import { getBooks, getAuthors } from '../services/api';

function BookList() {
  const [books, setBooks] = useState([]);
  const [authors, setAuthors] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    async function fetchData() {
      try {
        const [booksData, authorsData] = await Promise.all([
          getBooks(),
          getAuthors()
        ]);
        setBooks(booksData);
        setAuthors(authorsData);
      } catch (err) {
        setError('Failed to load data. Please try again later.');
      } finally {
        setLoading(false);
      }
    }
    fetchData();
  }, []);

  function getAuthorName(authorID) {
    const author = authors.find(a => a.authorID === authorID);
    return author ? author.authorName : 'Unknown Author';
  }

  if (loading) {
    return (
      <div className="text-center mt-5">
        <div className="spinner-border text-primary" role="status">
          <span className="visually-hidden">Loading...</span>
        </div>
        <p className="mt-2">Loading books...</p>
      </div>
    );
  }

  if (error) {
    return <div className="alert alert-danger mt-3">{error}</div>;
  }

  return (
    <div className="container mt-4">
      <h2 className="mb-4">
        <i className="fas fa-book me-2"></i>Book List
      </h2>
      <div className="row">
        {books.map(book => (
          <div key={book.bookID} className="col-md-4 col-lg-3 mb-4">
            <div className="card h-100 shadow-sm">
              <img
                src={book.imageUrl}
                className="card-img-top"
                alt={book.title}
                style={{ height: '280px', objectFit: 'cover' }}
                onError={(e) => {
                  e.target.src = 'https://via.placeholder.com/200x280?text=No+Image';
                }}
              />
              <div className="card-body d-flex flex-column">
                <h5 className="card-title">{book.title}</h5>
                <p className="card-text text-muted">
                  <i className="fas fa-user me-1"></i>
                  {getAuthorName(book.authorID)}
                </p>
                <p className="card-text text-muted">
                  <i className="fas fa-calendar me-1"></i>
                  {book.releaseYear}
                </p>
                <p className="card-text mt-auto">
                  <span className="badge bg-success fs-6">
                    ${book.price.toFixed(2)}
                  </span>
                </p>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default BookList;
