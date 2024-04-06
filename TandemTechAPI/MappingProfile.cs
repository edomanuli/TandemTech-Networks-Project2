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
            CreateMap<PlanInfo, PlanInfoDto>();

            CreateMap<UserPlan, UserPlanDto>();
            CreateMap<UserPlanCreateDto, UserPlan>();

            CreateMap<AssignedNumber, AssignedNumberDto>();
            CreateMap<AssignedNumberCreateDto, AssignedNumber>();

            CreateMap<MonthlyBill, MonthlyBillDto>();
            CreateMap<MonthlyBillCreateDto, MonthlyBill>();

            CreateMap<PlanBill, PlanBillDto>();
        }
    }
}
