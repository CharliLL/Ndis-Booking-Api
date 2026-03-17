using NDISBookingApi.Common.Enums;
using NDISBookingApi.Models;

namespace NDISBookingApi.DTOs.Booking
{
    public class BookingResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
