using AutoMapper;
using NDISBookingApi.DTOs.Service;
using NDISBookingApi.Models;
using NDISBookingApi.Repositories.ServiceM;

namespace NDISBookingApi.Services.ServiceM
{
    public class ServiceMService : IServiceMService
    {
        private readonly IServiceMRepository _serviceMRepository;
        private readonly IMapper _mapper;
        public ServiceMService(IServiceMRepository serviceMRepository, IMapper mapper)
        {
            _serviceMRepository = serviceMRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponseDto> CreateService(CreateServiceRequestDto createServiceRequestDto)
        {
            var service = _mapper.Map<Service>(createServiceRequestDto);
            bool success = await _serviceMRepository.CreateService(service);

            if (!success)
            {
                throw new Exception("Failed to create service.");
            }
            return _mapper.Map<ServiceResponseDto>(service);
        }

        public async Task DeleteService(int id)
        {
            var existingService = await _serviceMRepository.GetServiceById(id);
            if (existingService == null)
            {
                throw new KeyNotFoundException($"Service with ID {id} not found.");
            }
            bool success = await _serviceMRepository.DeleteService(existingService);
            if (!success)
            {
                throw new Exception("Failed to delete service.");
            }
        }

        public async Task<List<ServiceResponseDto>> GetAllServices()
        {
            List<Service> services = await _serviceMRepository.GetAllServices();
            return _mapper.Map<List<ServiceResponseDto>>(services);
        }

        public async Task<ServiceResponseDto> GetServiceById(int id)
        {
            Service service = await _serviceMRepository.GetServiceById(id);
            if (service == null)
            {
                throw new KeyNotFoundException($"Service with ID {id} not found.");
            }
            return _mapper.Map<ServiceResponseDto>(service);
        }

        public async Task UpdateService(int id, UpdateServiceRequestDto serviceRequest)
        {
            var existingService = await _serviceMRepository.GetServiceById(id);
            if (existingService == null)
            {
                throw new KeyNotFoundException($"Service with ID {id} not found.");
            }
            _mapper.Map(serviceRequest, existingService);
            bool success = await _serviceMRepository.UpdateService(existingService);
            if (!success)
            {
                throw new Exception("Failed to update service.");
            }
        }
    }
}
