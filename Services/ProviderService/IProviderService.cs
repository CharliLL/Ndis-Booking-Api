using NDISBookingApi.DTOs.Provider;
using NDISBookingApi.Models;

namespace NDISBookingApi.Services.ProviderService
{
    public interface IProviderService
    {
        Task<List<ProviderResponseDto>> GetAllProviders();
        Task<ProviderResponseDto> GetProviderById(int id);
        Task<ProviderResponseDto> CreateProvider(CreateProviderRequestDto createProviderRequestDto);
        Task UpdateProvider(int id, UpdateProviderRequestDto updateProviderRequestDto);
        Task DeleteProvider(int id);
    }
}
