using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles() 
    {
        CreateMap<AppUser, MembersDto>()
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));
        CreateMap<Portfolio, PortfolioDto>();
    }
}
