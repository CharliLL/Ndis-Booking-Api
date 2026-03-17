namespace NDISBookingApi.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Rating { get; set; }
        public string Bio { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<ProviderService> ProviderServices { get; set; }
    }
}
