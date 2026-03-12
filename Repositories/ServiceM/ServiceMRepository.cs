using Microsoft.EntityFrameworkCore;
using NDISBookingApi.Data;
using NDISBookingApi.Models;

namespace NDISBookingApi.Repositories.ServiceM
{
    public class ServiceMRepository : IServiceMRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceMRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateService(Service service)
        {
            await _context.Services.AddAsync(service);
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> DeleteService(Service service)
        {
            _context.Services.Remove(service);
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<List<Service>> GetAllServices()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service?> GetServiceById(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> UpdateService(Service service)
        {
            _context.Services.Update(service);
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }
    }
}
