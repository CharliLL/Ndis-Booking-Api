namespace NDISBookingApi.DTOs.Service
{
    public class UpdateServiceRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}
