namespace NDISBookingApi.DTOs.Provider
{
    public class UpdateProviderRequestDto
    {

        public int UserId { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Rating { get; set; }
        public string Bio { get; set; }

    }
}
