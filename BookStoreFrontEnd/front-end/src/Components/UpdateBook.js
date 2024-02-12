import { useState } from "react";
import './UpdateBook.css';

function UpdateBook(){
    const [title, setTitle] = useState("");
    const [price, setPrice] = useState();
    const [author, setAuthor] = useState("");
    const [genre, setGenre] = useState("");
    const [publishedDate, setPublishedDate] = useState("");
    const [isbn, setIsbn] = useState();
    const [bookId, setBookId] = useState("");

    const clickUpdate = () => {
        const book = {
            "id": bookId,
            "title": title,
            "price": price,
            "author": author,
            "genre": genre,
            "publishedDate": publishedDate,
            "isbn": isbn
        };

        fetch('http://localhost:5167/api/book', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem("token")
            },
            body: JSON.stringify(book)
        }).then(async (data) => {
            const myData = await data.json();
            console.log(myData);
            alert("Book Details Updated Successfully!!");
        }).catch((e) => {
            console.log(e);
        });
    };

    return (
        <form className="update">
            <div className="form-group">
                <h2>Update Book</h2>
                <input type="text" className="form-control" placeholder="Book Id" value={bookId} onChange={(e) => setBookId(e.target.value)} />
                <input type="text" className="form-control" placeholder="Book Title" value={title} onChange={(e) => setTitle(e.target.value)} />
                <input type="text" className="form-control" placeholder="Author" value={author} onChange={(e) => setAuthor(e.target.value)} />
                <input type="text" className="form-control" placeholder="Genre" value={genre} onChange={(e) => setGenre(e.target.value)} />
                <input type="text" className="form-control" placeholder="Price" value={price} onChange={(e) => setPrice(e.target.value)} />
                <input type="date" className="form-control" placeholder="Published Date" value={publishedDate} onChange={(e) => setPublishedDate(e.target.value)} />
                <input type="number" className="form-control" placeholder="ISBN" value={isbn} onChange={(e) => setIsbn(e.target.value)} />
            </div>
            <button onClick={clickUpdate} className="btn btn-primary"><b>Update Book</b></button>
        </form>
    );
}

export default UpdateBook;
