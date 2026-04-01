using Microsoft.EntityFrameworkCore;
using NDISBookingApi.Data;
using NDISBookingApi.Models;

namespace NDISBookingApi.Repositories.ProviderRepository
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ApplicationDbContext _context;
        public ProviderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateProvider(Provider provider)
        {
            await _context.Providers.AddAsync(provider);
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> DeleteProvider(Provider provider)
        {
            _context.Providers.Remove(provider);
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<List<Provider>> GetAllProviders()
        {
            return await _context.Providers
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Provider?> GetProviderById(int id)
        {
            return await _context.Providers
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> UpdateProvider(Provider provider)
        {
            _context.Providers.Update(provider);
            int changes = await _context.SaveChangesAsync();    
            return changes > 0;
        }
    }
}
