using AutoMapper;
using Bira.App.TechsysLog.Domain.DTOs.Request;
using Bira.App.TechsysLog.Domain.DTOs.Response;
using Bira.App.TechsysLog.Domain.Entities;

namespace Bira.App.TechsysLog.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Request, RequestDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Request, RequestResponse>()
                .ForMember(dest => dest.Delivered, opt => opt.MapFrom(src => src.DateDelivery != null));
        }
    }
}
