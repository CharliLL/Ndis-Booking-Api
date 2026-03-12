using NDISBookingApi.Common.Enums;

namespace NDISBookingApi.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProviderId { get; set; }
        public int ServiceId { get; set; }
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public Provider Provider { get; set; }
        public Service Service { get; set; }
    }
}
