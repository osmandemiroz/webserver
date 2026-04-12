import { render, screen } from '@testing-library/react';
import App from './App';

test('renders Book Library navbar', () => {
  render(<App />);
  const navElement = screen.getByText(/Book Library/i);
  expect(navElement).toBeInTheDocument();
});
