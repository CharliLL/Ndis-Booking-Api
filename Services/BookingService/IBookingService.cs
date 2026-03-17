using NDISBookingApi.DTOs.Booking;

namespace NDISBookingApi.Services.BookingService
{
    public interface IBookingService
    {
        Task<List<BookingResponseDto>> GetAllBookings();
        Task<BookingResponseDto> GetBookingById(int id);
        Task<BookingResponseDto> CreateBooking(CreateBookingRequestDto createBookingRequestDto);
        Task UpdateBooking(int id, UpdateBookingRequestDto updateBookingRequestDto);
        Task DeleteBooking(int id);
    }
}
