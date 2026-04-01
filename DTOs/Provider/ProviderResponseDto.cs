using NDISBookingApi.Models;

namespace NDISBookingApi.DTOs.Provider
{
    public class ProviderResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Rating { get; set; }
        public string Bio { get; set; }
        public DateTime CreatedAt { get; set; } 
        public string? UserName { get; set; }
    }
}
