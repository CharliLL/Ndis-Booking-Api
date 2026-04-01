using NDISBookingApi.Models;

namespace NDISBookingApi.Repositories.ProviderRepository
{
    public interface IProviderRepository
    {
        Task<List<Provider>> GetAllProviders();
        Task<Provider?> GetProviderById(int id);
        Task<bool> CreateProvider(Provider provider);
        Task<bool> UpdateProvider(Provider provider);
        Task<bool> DeleteProvider(Provider provider);

    }
}
