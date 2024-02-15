using Microsoft.EntityFrameworkCore;
using EventManagement.Models;

namespace EventManagement.Contexts
{
    public class EventManagementContext : DbContext
    {
        public EventManagementContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }


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
