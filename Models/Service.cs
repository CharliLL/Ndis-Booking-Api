namespace NDISBookingApi.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<Booking> Bookings { get; set; }
        public List<ProviderService> ProviderServices { get; set; }
    }
}
