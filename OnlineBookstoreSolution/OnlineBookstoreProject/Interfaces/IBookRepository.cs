
using OnlineBookstoreProject.Models;

namespace OnlineBookstoreProject.Interfaces
{
    public interface IBookRepository
    {
        public Book Add(Book item);
        public Book Delete(int key);
        public Book GetById(int key);
        public IList<Book> GetAll();
        public Book Update(Book item);
    }
}
