using OnlineBookStore.Exceptions;
using OnlineBookStore.Models.DTOs;
using OnlineBookstoreProject.Exceptions;
using OnlineBookstoreProject.Interfaces;
using OnlineBookstoreProject.Models;
using OnlineBookstoreProject.Models.DTOs;

namespace OnlineBookstoreProject.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

       
        public BookService(IBookRepository repository)
        {
            _bookRepository = repository;
        }
        public Book Add(Book book)
        {
            var result = _bookRepository.Add(book);
            return result;
        }

        public Book GetBookById(BookIdDTO bookIdDTO)
        {
            var result = _bookRepository.GetById(bookIdDTO.BookId);
            return result;
        }

        public List<Book> GetBooks()
        {
            var books = _bookRepository.GetAll();
            if (books != null)
            {
                return books.ToList();
            }
            throw new NoBooksAvailableException();
        }

        public BookIdDTO RemoveBook(BookIdDTO bookIdDTO)
        {
            var BookToBeRemoved = _bookRepository.GetById(bookIdDTO.BookId);
            if (BookToBeRemoved != null)
            {
                var result = _bookRepository.Delete(bookIdDTO.BookId);
                if (result != null)
                {
                    return bookIdDTO;
                }
            }
            return null;
        }

        public UpdateBookDTO UpdateBook(UpdateBookDTO bookDTO)
        {
            var bookData = _bookRepository.GetById(bookDTO.BookId);
            bookData.Title = bookDTO.Title;
            bookData.Genre = bookDTO.Genre;
            bookData.Author = bookDTO.Author;
            bookData.Price = bookDTO.Price;
            bookData.ISBN = bookDTO.ISBN;

            if (bookData != null)
            {
                var result = _bookRepository.Update(bookData);
                if (result != null)
                {
                    return bookDTO;
                }
            }
            return null;
        }
    }
}
