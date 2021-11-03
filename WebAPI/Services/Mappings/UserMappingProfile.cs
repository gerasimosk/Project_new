using AutoMapper;
using WebAPI.Domain;
using WebAPI.Services.DTOs;

namespace WebAPI.Services.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            EntityToDTO();
        }

        private void EntityToDTO()
        {
            CreateMap<User, UserDetails>()
                .ForMember(des => des.UserTitle, src => src.MapFrom(u => u.UserTitle.Description))
                .ForMember(des => des.UserType, src => src.MapFrom(u => u.UserType.Description));

            CreateMap<UserDetails, User>()
                .ForMember(des => des.UserTitleId, src => src.MapFrom(u => u.UserTitleId))
                .ForMember(des => des.UserTypeId, src => src.MapFrom(u => u.UserTypeId));
        }
    }
}
