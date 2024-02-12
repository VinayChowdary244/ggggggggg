using Microsoft.EntityFrameworkCore;
using OnlineBookstoreProject.Models;

namespace OnlineBookstoreProject.Contexts
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }


        // public DbSet<User> Users { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // Convert the list of selected seats to a comma-separated string and vice versa for the Booking entity
        //     modelBuilder.Entity<Booking>()
        //         .Property(b => b.SelectedSeats)
        //         .HasConversion(
        //             v => string.Join(',', v),
        //             v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
        //         );



    }
}
