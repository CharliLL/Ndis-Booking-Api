using NDISBookingApi.Common.Enums;

namespace NDISBookingApi.DTOs.Booking
{
    public class CreateBookingRequestDto
    {
        public int UserId { get; set; }
        public int ProviderId { get; set; }
        public int ServiceId { get; set; }
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; }
        
    }
}
