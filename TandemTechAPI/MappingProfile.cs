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

            CreateMap<MonthlyBill, MonthlyBillDto>();
            CreateMap<MonthlyBillCreateDto, MonthlyBill>();

            CreateMap<PlanBill, PlanBillDto>();

            CreateMap<Device, DeviceDto>();
            CreateMap<DeviceInfo, DeviceInfoDto>();

            CreateMap<DeviceCreateDto, Device>()
             .ForMember(dest => dest.AssignedNumber, opt => opt.Ignore())
             .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
