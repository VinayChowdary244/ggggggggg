

import React, { useState } from "react";
import './AddBook.css'
import { redirect } from "react-router-dom";

function AddBook() {
  const [title, setTitle] = useState("");
  const [author, setAuthor] = useState();
  const [genre, setGenre] = useState("");
  const [publishDate, setPublishDate] = useState("");
  const [isbn, setIsbn] = useState("");
  const [price, setPrice] = useState("");
 

  var book;

  var clickAdd = () => {
    book = {
      "title": title,
      "author": author,
      "genre": genre,
      "isbn": isbn,
      "publishDate": publishDate,
      "price": price,
      
    };

    fetch('http://localhost:5167/api/book', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem("token")
      },
      body: JSON.stringify(book)
    }).then(
      () => {
        console.log(book);
        alert('Book Added');
      }
    ).catch((e) => {
      console.log(e)
    });
  }

  return (
    <div className="add">
      <h2>Add Book</h2>

      <label className="form-control" for="pname"><b>Book Title</b></label>
      <input id="pname" type="text" className="form-control" value={title} onChange={(e) => { setTitle(e.target.value) }} />
      <label className="form-control" for="pname"><b>Author</b></label>
      <input id="pname" type="text" className="form-control" value={author} onChange={(e) => { setAuthor(e.target.value) }} />
      <label className="form-control" for="pname"><b>Genre</b></label>
      <input id="pname" type="text" className="form-control" value={genre} onChange={(e) => { setGenre(e.target.value) }} />
      <label className="form-control" for="pprice"><b>ISBN</b></label>
      <input id="pprice" type="text" className="form-control" value={isbn} onChange={(e) => { setIsbn(e.target.value) }} />
      <label className="form-control" for="pprice"><b>Published Date </b></label>
      <input id="pprice" type="date" className="form-control" value={publishDate} onChange={(e) => { setPublishDate(e.target.value) }} />
      <label className="form-control" for="pprice"><b>Price</b></label>
      <input id="pprice" type="number" className="form-control" value={price} onChange={(e) => { setPrice(e.target.value) }} />
      
      <button onClick={clickAdd} className="btn btn-primary"><b>Add Book</b></button>
    </div>
  );
}

export default AddBook;
