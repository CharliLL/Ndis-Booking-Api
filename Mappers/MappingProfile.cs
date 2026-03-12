using AutoMapper;
using NDISBookingApi.DTOs.Service;
using NDISBookingApi.Models;

namespace NDISBookingApi.Mappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Service, ServiceResponseDto>();
            CreateMap<CreateServiceRequestDto, Service>();
            CreateMap<UpdateServiceRequestDto, Service>();
        }
    }
}
