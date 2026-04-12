import React, { useEffect, useState } from 'react';
import { getUsers, getBooks } from '../services/api';

function RentBook({ users: propUsers, books: propBooks, onRent }) {
  const [users, setUsers] = useState(propUsers || []);
  const [books, setBooks] = useState(propBooks || []);
  const [selectedUserID, setSelectedUserID] = useState('');
  const [selectedBookID, setSelectedBookID] = useState('');
  const [loading, setLoading] = useState(!propUsers || !propBooks);
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);

  useEffect(() => {
    if (propUsers) setUsers(propUsers);
  }, [propUsers]);

  useEffect(() => {
    if (propBooks) setBooks(propBooks);
  }, [propBooks]);

  useEffect(() => {
    if (propUsers && propBooks) {
      setLoading(false);
      return;
    }
    async function fetchData() {
      try {
        const [usersData, booksData] = await Promise.all([
          getUsers(),
          getBooks()
        ]);
        if (!propUsers) setUsers(usersData);
        if (!propBooks) setBooks(booksData);
      } catch (err) {
        setError('Failed to load data. Please try again later.');
      } finally {
        setLoading(false);
      }
    }
    fetchData();
  }, [propUsers, propBooks]);

  function getAvailableBooks() {
    if (!selectedUserID) return books;
    const user = users.find(u => u.userID === parseInt(selectedUserID));
    if (!user) return books;
    return books.filter(b => !user.rentedBookIDs.includes(b.bookID));
  }

  function handleRent(e) {
    e.preventDefault();
    setError(null);
    setSuccess(null);

    if (!selectedUserID || !selectedBookID) {
      setError('Please select both a user and a book.');
      return;
    }

    const userID = parseInt(selectedUserID);
    const bookID = parseInt(selectedBookID);
    const user = users.find(u => u.userID === userID);
    const book = books.find(b => b.bookID === bookID);

    if (!user || !book) {
      setError('Invalid user or book selection.');
      return;
    }

    if (user.rentedBookIDs.includes(bookID)) {
      setError(`${user.name} has already rented "${book.title}".`);
      return;
    }

    const updatedUsers = users.map(u => {
      if (u.userID === userID) {
        return {
          ...u,
          rentedBookIDs: [...u.rentedBookIDs, bookID]
        };
      }
      return u;
    });

    setUsers(updatedUsers);
    if (onRent) onRent(updatedUsers);
    setSuccess(`"${book.title}" has been rented to ${user.name} successfully!`);
    setSelectedBookID('');
  }

  if (loading) {
    return (
      <div className="text-center mt-5">
        <div className="spinner-border text-primary" role="status">
          <span className="visually-hidden">Loading...</span>
        </div>
        <p className="mt-2">Loading data...</p>
      </div>
    );
  }

  const availableBooks = getAvailableBooks();

  return (
    <div className="container mt-4">
      <h2 className="mb-4">
        <i className="fas fa-hand-holding me-2"></i>Rent a Book
      </h2>

      {error && (
        <div className="alert alert-danger alert-dismissible fade show">
          {error}
          <button
            type="button"
            className="btn-close"
            onClick={() => setError(null)}
          ></button>
        </div>
      )}

      {success && (
        <div className="alert alert-success alert-dismissible fade show">
          {success}
          <button
            type="button"
            className="btn-close"
            onClick={() => setSuccess(null)}
          ></button>
        </div>
      )}

      <div className="card shadow-sm">
        <div className="card-body">
          <form onSubmit={handleRent}>
            <div className="mb-3">
              <label htmlFor="userSelect" className="form-label">
                <i className="fas fa-user me-1"></i>Select User
              </label>
              <select
                id="userSelect"
                className="form-select"
                value={selectedUserID}
                onChange={(e) => {
                  setSelectedUserID(e.target.value);
                  setSelectedBookID('');
                  setError(null);
                  setSuccess(null);
                }}
              >
                <option value="">-- Choose a user --</option>
                {users.map(user => (
                  <option key={user.userID} value={user.userID}>
                    {user.name} ({user.email})
                  </option>
                ))}
              </select>
            </div>

            <div className="mb-3">
              <label htmlFor="bookSelect" className="form-label">
                <i className="fas fa-book me-1"></i>Select Book
              </label>
              <select
                id="bookSelect"
                className="form-select"
                value={selectedBookID}
                onChange={(e) => {
                  setSelectedBookID(e.target.value);
                  setError(null);
                }}
                disabled={!selectedUserID}
              >
                <option value="">-- Choose a book --</option>
                {availableBooks.map(book => (
                  <option key={book.bookID} value={book.bookID}>
                    {book.title} (${book.price.toFixed(2)})
                  </option>
                ))}
              </select>
              {selectedUserID && availableBooks.length === 0 && (
                <div className="form-text text-warning">
                  This user has already rented all available books.
                </div>
              )}
            </div>

            <button
              type="submit"
              className="btn btn-primary"
              disabled={!selectedUserID || !selectedBookID}
            >
              <i className="fas fa-check me-1"></i>Rent Book
            </button>
          </form>
        </div>
      </div>
    </div>
  );
}

export default RentBook;
