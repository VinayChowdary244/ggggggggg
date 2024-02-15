import React, { useState, useEffect } from "react";
import "./Home.css";
 
function Home() {
  const [searchTerm, setSearchTerm] = useState("");
  const [books, setBooks] = useState([]);
  const [bookList, setBookList] = useState([]);
  const [searchPerformed, setSearchPerformed] = useState(false);
 
  useEffect(() => {
    getBooks();
  }, []);
 
  var getBooks = () => {
    fetch("http://localhost:5167/api/book/GetAllBooks", {
      method: "GET",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
        Authorization: "Bearer " + localStorage.getItem("token"),
      },
    })
      .then(async (data) => {
        var myData = await data.json();
        console.log(myData);
        await setBookList(myData);
        await setSearchPerformed(true);
        var BookId = data.BookId;
        localStorage.setItem("BookId", BookId);
      })
      .catch((e) => {
        console.log(e);
      });
  };
 
  const handleSearch = () => {
    const filteredBooks = bookList.filter(book =>
      book.title.toLowerCase().includes(searchTerm.toLowerCase()) ||
      book.author.toLowerCase().includes(searchTerm.toLowerCase()) ||
      book.genre.toLowerCase().includes(searchTerm.toLowerCase())
    );
    setBooks(filteredBooks);
  };
 
  return (
    <div className="home-container">
      <h1 className="page-title">Search Books</h1>
      <div className="search-container">
        <input
          type="text"
          placeholder="Search by title, author, or genre..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
        <button onClick={handleSearch}>Search</button>
      </div>
      <div className="results-container">
        {searchPerformed && (
          books.length > 0 ? (
            <div className="book-tiles">
              {books.map((book) => (
                <div key={book.bookId} className="book-tile">
                  <h2>{book.title}</h2>
                  <p><strong>Author:</strong> {book.author}</p>
                  <p><strong>Genre:</strong> {book.genre}</p>
                  <p><strong>Price:</strong> ${book.price}</p>
                  <p><strong>Publish Date:</strong> {book.publishDate}</p>
                </div>
              ))}
            </div>
          ) : (
            <p>No books found.</p>
          )
        )}
      </div>
    </div>
  );
}
 
export default Home;
 