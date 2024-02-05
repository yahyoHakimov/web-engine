using AutoMapper;
using WebApplication4.DTO;
using WebApplication4.Models;

namespace WebApplication4.Profiles
{
    public class LogInfoProfile : Profile
    {
        public LogInfoProfile()
        {
            CreateMap<LogInfoCreateDto, LogInfo>();
            CreateMap<LogInfo, LogInfotReadDto>();
            CreateMap<LogInfo, LogInfoUpdateDto>();
            CreateMap<LogInfoUpdateDto, LogInfo>();

        }
    }

}
