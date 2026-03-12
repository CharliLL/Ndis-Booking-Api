using NDISBookingApi.Common.Enums;

namespace NDISBookingApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public Provider? Provider { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
