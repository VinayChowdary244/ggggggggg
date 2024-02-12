using System.Collections.Generic;
using System.Reflection.Emit;

namespace PracticeProject.Contexts
{
    public class TicketingContext : DbContext
    {
        // Constructor to initialize the context with provided options
        public TicketingContext(DbContextOptions options) : base(options)
        {

        }

        // Database tables represented as DbSet properties
       
        // Method to configure data conversions for specific properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Convert the list of selected seats to a comma-separated string and vice versa for the Booking entity
            modelBuilder.Entity<Booking>()
                .Property(b => b.SelectedSeats)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
                );

            // Convert the list of booked seats to a comma-separated string and vice versa for the BookedSeat entity
            modelBuilder.Entity<BookedSeat>()
               .Property(b => b.BookedSeats)
               .HasConversion(
                   v => string.Join(',', v),
                   v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
               );

            // Convert the list of cancelled seats to a comma-separated string and vice versa for the CancelledBooking entity
            modelBuilder.Entity<CancelledBooking>()
               .Property(b => b.CancelledSeats)
               .HasConversion(
                   v => string.Join(',', v),
                   v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
               );

            // Ignore certain properties to prevent errors during database operations
            // modelBuilder.Entity<BookedSeat>()
            //   .Ignore(b => b.Date);

            // modelBuilder.Entity<Booking>()
            //     .Ignore(b => b.Date);

            // modelBuilder.Entity<CancelledBooking>()
            //     .Ignore(b => b.Date);
        }
    }
}
