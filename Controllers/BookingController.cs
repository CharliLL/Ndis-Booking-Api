using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDISBookingApi.DTOs.Booking;
using NDISBookingApi.Services.BookingService;

namespace NDISBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        /// <summary>
        /// Get all bookings.
        /// </summary>
        /// <returns>A list of all bookings.</returns>
        /// <response code="200">Bookings retrieved successfully.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<BookingResponseDto>>> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookings();
            return Ok(bookings);
        }

        /// <summary>
        /// Get a booking by ID.
        /// </summary>
        /// <param name="id">The ID of the booking.</param>
        /// <returns>The booking details.</returns>
        /// <response code="200">Booking retrieved successfully.</response>
        /// <response code="404">Booking not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookingResponseDto>> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingById(id);
            return Ok(booking);
        }

        /// <summary>
        /// Create a new booking.
        /// </summary>
        /// <param name="createBookingRequestDto">The booking data to create.</param>
        /// <returns>The newly created booking.</returns>
        /// <response code="201">Booking created successfully.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="404">Related user, provider, or service not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookingResponseDto>> CreateBooking(CreateBookingRequestDto createBookingRequestDto)
        {
            var createdBooking = await _bookingService.CreateBooking(createBookingRequestDto);

            return CreatedAtAction(
                nameof(GetBookingById),
                new { id = createdBooking.Id },
                createdBooking
            );
        }

        /// <summary>
        /// Update an existing booking.
        /// </summary>
        /// <param name="id">The ID of the booking to update.</param>
        /// <param name="updateBookingRequestDto">The updated booking data.</param>
        /// <response code="204">Booking updated successfully.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="404">Booking or related user, provider, or service not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBooking(int id, UpdateBookingRequestDto updateBookingRequestDto)
        {
            await _bookingService.UpdateBooking(id, updateBookingRequestDto);
            return NoContent();
        }

        /// <summary>
        /// Delete a booking by ID.
        /// </summary>
        /// <param name="id">The ID of the booking to delete.</param>
        /// <response code="204">Booking deleted successfully.</response>
        /// <response code="404">Booking not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteBooking(id);
            return NoContent();
        }
    }
}
