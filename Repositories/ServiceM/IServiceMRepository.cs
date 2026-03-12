using NDISBookingApi.Models;

namespace NDISBookingApi.Repositories.ServiceM
{
    public interface IServiceMRepository
    {
        Task<List<Service>> GetAllServices();
        Task<Service?> GetServiceById(int id);
        Task<bool> CreateService(Service service);
        Task<bool> UpdateService(Service service);
        Task<bool> DeleteService(Service service);
    }
}
