using AutoMapper;
using WebApplication4.DTO;
using WebApplication4.Models;

namespace WebApplication4.Profiles
{
    public class UserInfoProfile : Profile
    {
            public UserInfoProfile()
        {
            CreateMap<UserInfoCreateDto, UserInfo>();
            CreateMap<UserInfo, UserInfoReadDto>();
            CreateMap<UserInfo, UserInfoUpdateDto>();
            CreateMap<UserInfoUpdateDto, UserInfo>();
        }
    }
}
