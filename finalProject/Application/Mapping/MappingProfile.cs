using Application.Dtos.Request.Users;
using AutoMapper;
using Domain.Entity;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Users
        CreateMap<User, UserSignUpDto>().ReverseMap();

        
    }
}