import axios from 'axios';

const REMOTE_BASE = 'https://raw.githubusercontent.com/emindk/JSON_Files/refs/heads/main';
const LOCAL_BASE = '/data';

async function fetchData(filename) {
  try {
    const response = await axios.get(`${REMOTE_BASE}/${filename}`);
    return response.data;
  } catch {
    const response = await axios.get(`${LOCAL_BASE}/${filename}`);
    return response.data;
  }
}

export async function getAuthors() {
  return fetchData('authors.json');
}

export async function getBooks() {
  return fetchData('books.json');
}

export async function getUsers() {
  return fetchData('users.json');
}
