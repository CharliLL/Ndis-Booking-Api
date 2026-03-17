using NDISBookingApi.Models;

namespace NDISBookingApi.Repositories.BookingREpository
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookings();
        Task<Booking?> GetBookingById(int id);
        Task<bool> CreateBooking(Booking booking);
        Task<bool> UpdateBooking(Booking booking);
        Task<bool> DeleteBooking(Booking booking);
    }
}
