using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NDISBookingApi.Data;
using NDISBookingApi.DTOs.Provider;
using NDISBookingApi.Models;
using NDISBookingApi.Repositories.ProviderRepository;

namespace NDISBookingApi.Services.ProviderService
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ProviderService(IProviderRepository providerRepository, IMapper mapper, ApplicationDbContext context)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ProviderResponseDto> CreateProvider(CreateProviderRequestDto createProviderRequestDto)
        {
            await ValidateForeignkeys(createProviderRequestDto.UserId);
            Provider provider = _mapper.Map<Provider>(createProviderRequestDto);
            bool success = await _providerRepository.CreateProvider(provider);
            if (!success)
            {
                throw new Exception("Failed to create provider.");
            }
            var createdProvider = await _providerRepository.GetProviderById(provider.Id);
            if (createdProvider == null)
            {
                throw new Exception("Failed to retrieve created provider.");
            }
            return _mapper.Map<ProviderResponseDto>(createdProvider);
        }

        public async Task DeleteProvider(int id)
        {
            Provider provider = await _providerRepository.GetProviderById(id);
            if (provider == null)
            {
                throw new KeyNotFoundException($"Provider with id {id} not found");
            }
            bool success = await _providerRepository.DeleteProvider(provider);
            if (!success)
            {
                throw new Exception("Failed to delete provider.");
            }
        }

        public async Task<List<ProviderResponseDto>> GetAllProviders()
        {
            List<Provider> providers = await _providerRepository.GetAllProviders();
            return _mapper.Map<List<ProviderResponseDto>>(providers);
        }

        public async Task<ProviderResponseDto> GetProviderById(int id)
        {
            Provider provider = await _providerRepository.GetProviderById(id);
            if (provider == null)
            {
                throw new KeyNotFoundException($"Provider with id {id} not found");
            }
            return _mapper.Map<ProviderResponseDto>(provider);
        }

        public async Task UpdateProvider(int id, UpdateProviderRequestDto updateProviderRequestDto)
        {
            var existingProvider = await _providerRepository.GetProviderById(id);
            if (existingProvider == null)
            {
                throw new KeyNotFoundException($"Provider with id {id} not found");
            }
            await ValidateForeignkeys(updateProviderRequestDto.UserId);
            _mapper.Map(updateProviderRequestDto, existingProvider);
            bool success = await _providerRepository.UpdateProvider(existingProvider);
            if (!success)
            {
                throw new Exception("Failed to update provider.");
            }
        }

        public async Task ValidateForeignkeys(int userId)
        {
            bool userExits = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExits)
            {
                throw new KeyNotFoundException($"User with id {userId} does not exist");
            }
        }
    }
}
