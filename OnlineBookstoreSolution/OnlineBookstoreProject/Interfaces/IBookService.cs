using OnlineBookStore.Models.DTOs;
using OnlineBookstoreProject.Models;
using OnlineBookstoreProject.Models.DTOs;

namespace OnlineBookstoreProject.Interfaces
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book Add(Book book);
        BookIdDTO RemoveBook( BookIdDTO bookIdDTO);
        UpdateBookDTO UpdateBook(UpdateBookDTO bookDTO);
        Book GetBookById(BookIdDTO bookIdDTO);
    }
}
