import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Navbar from './components/Navbar';
import BookList from './components/BookList';
import UserList from './components/UserList';
import RentBook from './components/RentBook';
import { getUsers, getBooks } from './services/api';
import './App.css';

function App() {
  const [users, setUsers] = useState(null);
  const [books, setBooks] = useState(null);

  useEffect(() => {
    async function fetchData() {
      try {
        const [usersData, booksData] = await Promise.all([
          getUsers(),
          getBooks()
        ]);
        setUsers(usersData);
        setBooks(booksData);
      } catch (err) {
        console.error('Failed to load initial data:', err);
      }
    }
    fetchData();
  }, []);

  function handleRent(updatedUsers) {
    setUsers(updatedUsers);
  }

  return (
    <Router>
      <div className="App">
        <Navbar />
        <Routes>
          <Route path="/" element={<BookList />} />
          <Route
            path="/users"
            element={<UserList users={users} books={books} />}
          />
          <Route
            path="/rent"
            element={
              <RentBook users={users} books={books} onRent={handleRent} />
            }
          />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
