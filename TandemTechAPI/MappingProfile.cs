using AutoMapper;
using DTOs;
using Entities;

namespace TandemTechAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<PlanInfoDto, PlanInfo>();

            // Add this line to map from Entities.PlanInfo to DTOs.PlanInfoDto
            CreateMap<PlanInfo, PlanInfoDto>();
        }
    }
}
