import React, { useEffect, useState } from 'react';
import { getUsers, getBooks } from '../services/api';

function UserList({ users: propUsers, books: propBooks }) {
  const [users, setUsers] = useState(propUsers || []);
  const [books, setBooks] = useState(propBooks || []);
  const [loading, setLoading] = useState(!propUsers || !propBooks);
  const [error, setError] = useState(null);

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

  function getBookTitle(bookID) {
    const book = books.find(b => b.bookID === bookID);
    return book ? book.title : 'Unknown Book';
  }

  if (loading) {
    return (
      <div className="text-center mt-5">
        <div className="spinner-border text-primary" role="status">
          <span className="visually-hidden">Loading...</span>
        </div>
        <p className="mt-2">Loading users...</p>
      </div>
    );
  }

  if (error) {
    return <div className="alert alert-danger mt-3">{error}</div>;
  }

  return (
    <div className="container mt-4">
      <h2 className="mb-4">
        <i className="fas fa-users me-2"></i>User List
      </h2>
      <div className="table-responsive">
        <table className="table table-striped table-hover">
          <thead className="table-dark">
            <tr>
              <th>#</th>
              <th>Name</th>
              <th>Email</th>
              <th>Rented Books</th>
            </tr>
          </thead>
          <tbody>
            {users.map(user => (
              <tr key={user.userID}>
                <td>{user.userID}</td>
                <td>
                  <i className="fas fa-user me-1"></i>
                  {user.name}
                </td>
                <td>
                  <i className="fas fa-envelope me-1"></i>
                  {user.email}
                </td>
                <td>
                  {user.rentedBookIDs && user.rentedBookIDs.length > 0 ? (
                    user.rentedBookIDs.map(bookID => (
                      <span
                        key={bookID}
                        className="badge bg-info text-dark me-1 mb-1"
                      >
                        {getBookTitle(bookID)}
                      </span>
                    ))
                  ) : (
                    <span className="text-muted">No books rented</span>
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default UserList;
