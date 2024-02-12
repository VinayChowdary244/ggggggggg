import React, { useState, useEffect } from "react";
import "./Books.css";

function Books() {
  const [bookList, setBookList] = useState([]);
  const [searchPerformed, setSearchPerformed] = useState(false);

  useEffect(() => {
    getBooks();
  }, []); 

  var getBooks = () => {
    fetch("http://localhost:5167/api/book", {
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

  return (
    <div className="books-container">
      <h1 className="page-title">Books</h1>
      {searchPerformed && (
        <div className="book-tiles">
          {bookList.map((book, index) => (
            <div key={book.bookId} className="book-tile">
              <h2>{book.title}</h2>
              <p><strong>Author:</strong> {book.author}</p>
              <p><strong>Genre:</strong> {book.genre}</p>
              <p><strong>Published Date:</strong> {book.publishDate}</p>
              <p><strong>ISBN:</strong> {book.isbn}</p>
              <p><strong>Price:</strong> ${book.price}</p>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}

export default Books;
