using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NDISBookingApi.Data;
using NDISBookingApi.DTOs.Booking;
using NDISBookingApi.Models;
using NDISBookingApi.Repositories.BookingREpository;

namespace NDISBookingApi.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        
        public BookingService(IBookingRepository bookingRepository, IMapper mapper, ApplicationDbContext context)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<BookingResponseDto> CreateBooking(CreateBookingRequestDto createBookingRequestDto)
        {
            await ValidateForeignkeys(createBookingRequestDto.UserId, createBookingRequestDto.ProviderId, createBookingRequestDto.ServiceId);

            Booking booking = _mapper.Map<Booking>(createBookingRequestDto);
            bool success = await _bookingRepository.CreateBooking(booking);
            if (!success)
            {
                throw new Exception ("Failed to create booking.");
            }
            var createdBooking = await _bookingRepository.GetBookingById(booking.Id);
            if (createdBooking == null)
            {
                throw new Exception("Failed to retrieve created booking.");
            }
            return _mapper.Map<BookingResponseDto>(createdBooking);
        }

        public async Task DeleteBooking(int id)
        {
            var exitingBooking = await _bookingRepository.GetBookingById(id);
            if (exitingBooking == null)
            {
                throw new Exception($"Booking with id {id} not found");
            }
            bool success = await _bookingRepository.DeleteBooking(exitingBooking);
            if (!success)
            {
                throw new Exception("Failed to delete booking.");
            }
        }

        public async Task<List<BookingResponseDto>> GetAllBookings()
        {
            List<Booking> bookings = await _bookingRepository.GetAllBookings();
            return _mapper.Map<List<BookingResponseDto>>(bookings);
        }

        public async Task<BookingResponseDto> GetBookingById(int id)
        {
            Booking booking = await _bookingRepository.GetBookingById(id);
            if (booking == null)
            {
                throw new KeyNotFoundException($"Booking with id {id} not found");
            }
            return _mapper.Map<BookingResponseDto>(booking);
        }

        public async Task UpdateBooking(int id, UpdateBookingRequestDto updateBookingRequestDto)
        {
            var exitingBooking = await _bookingRepository.GetBookingById(id);
            if (exitingBooking == null)
            {
                throw new KeyNotFoundException($"Booking with id {id} not found");
            }
            await ValidateForeignkeys(updateBookingRequestDto.UserId, updateBookingRequestDto.ProviderId, updateBookingRequestDto.ServiceId);
            _mapper.Map(updateBookingRequestDto, exitingBooking);
            bool success = await _bookingRepository.UpdateBooking(exitingBooking);
            if (!success)
            {
                throw new Exception("Failed to update booking.");
            }
        }

        public async Task ValidateForeignkeys(int userId, int prodiverId, int serviceId)
        {
            bool userExits = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExits)
            {
                throw new KeyNotFoundException($"User with id {userId} does not exist");
            }
            bool providerExits = await _context.Providers.AnyAsync(p => p.Id == prodiverId);
            if (!providerExits)
            {
                throw new KeyNotFoundException($"Provider with id {prodiverId} does not exist");
            }
            bool serviceExits = await _context.Services.AnyAsync(s => s.Id == serviceId);
            if (!serviceExits)
            {
                throw new KeyNotFoundException($"Service with id {serviceId} does not exist");
            }
        }
    }
}
