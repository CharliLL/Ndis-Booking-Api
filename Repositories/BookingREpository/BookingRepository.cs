using Microsoft.EntityFrameworkCore;
using NDISBookingApi.Data;
using NDISBookingApi.Models;

namespace NDISBookingApi.Repositories.BookingREpository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> DeleteBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            return await _context.Bookings
                .Include(b => b.Service)
                .Include(b => b.Provider)
                .Include(b => b.User)
                .ToListAsync();
        }

        public async Task<Booking?> GetBookingById(int id)
        {
            return await _context.Bookings
                .Include(b => b.Service)
                .Include(b => b.Provider)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<bool> UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }
    }
}
