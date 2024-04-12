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
            CreateMap<UserRegistrationDto, User>();
            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<PlanInfoDto, PlanInfo>();
            CreateMap<PlanInfo, PlanInfoDto>();

            CreateMap<UserPlan, UserPlanDto>();
            CreateMap<UserPlanCreateDto, UserPlan>();

            CreateMap<PhoneNumber, PhoneNumberDto>();
            CreateMap<AssignedNumber, AssignedNumberDto>();
            CreateMap<AssignedNumberCreateDto, AssignedNumber>();

            CreateMap<MonthlyBill, MonthlyBillDto>();
            CreateMap<MonthlyBillCreateDto, MonthlyBill>();

            CreateMap<PlanBill, PlanBillDto>();

            CreateMap<Device, DeviceDto>();
            CreateMap<DeviceInfo, DeviceInfoDto>();
        }
    }
}
