using AutoMapper;
using NDISBookingApi.DTOs.Booking;
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

            CreateMap<Booking, BookingResponseDto>()
                .ForMember(d=>d.UserName, o=>o.MapFrom(s=>s.User.Name))
                .ForMember(d => d.ProviderName, o =>o.MapFrom(s => s.Provider.Name))
                .ForMember(d => d.ServiceName, o => o.MapFrom(s => s.Service.Name));
            CreateMap<CreateBookingRequestDto, Booking>();
            CreateMap<UpdateBookingRequestDto, Booking>();
        }
    }
}
