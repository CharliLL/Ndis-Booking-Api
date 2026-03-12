namespace NDISBookingApi.Models
{
    public class ProviderService
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public int ServiceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Provider Provider { get; set; }
        public Service Service { get; set; }
    }
}
