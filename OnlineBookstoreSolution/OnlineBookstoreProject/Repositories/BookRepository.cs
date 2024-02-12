using OnlineBookstoreProject.Contexts;
using OnlineBookstoreProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using OnlineBookstoreProject.Models;

namespace OnlineBookstoreProject.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public Book Add(Book item)
        {
            _context.Books.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Book Delete(int key)
        {
            var bus = GetById(key);
            if (bus != null)
            {
                _context.Books.Remove(bus);
                _context.SaveChanges();
                return bus;
            }
            return null;
        }

        public Book GetById(int key)
        {
            var bus = _context.Books.SingleOrDefault(x => x.BookId == key);
            return bus;
        }

        public IList<Book> GetAll()
        {
            if (_context.Books.Count() == 0)
            {
                return null;
            }
            return _context.Books.ToList();
        }

        public Book Update(Book entity)
        {
            var bus = GetById(entity.BookId);
            if (bus != null)
            {
                _context.Entry<Book>(bus).State = EntityState.Modified;
                _context.SaveChanges();
                return bus;
            }
            return null;
        }

        public void SetSampleBus(Book sampleBus)
        {
            throw new NotImplementedException();
        }
    }
}
