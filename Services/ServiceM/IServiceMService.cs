using NDISBookingApi.DTOs.Service;

namespace NDISBookingApi.Services.ServiceM
{
    public interface IServiceMService
    {
        Task<List<ServiceResponseDto>> GetAllServices();
        Task<ServiceResponseDto> GetServiceById(int id);
        Task<ServiceResponseDto> CreateService(CreateServiceRequestDto createServiceRequestDto);
        Task UpdateService(int id, UpdateServiceRequestDto updateServiceRequestDto);
        Task DeleteService(int id);
    }
}
