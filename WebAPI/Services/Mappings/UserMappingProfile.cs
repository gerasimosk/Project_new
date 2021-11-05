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
            DTOToEntity();
        }

        private void EntityToDTO()
        {
            CreateMap<User, UserDetailsDTO>()
                .ForMember(des => des.UserTitle, src => src.MapFrom(u => u.UserTitle.Description))
                .ForMember(des => des.UserType, src => src.MapFrom(u => u.UserType.Description));
        }

        private void DTOToEntity()
        {
            CreateMap<UserDetailsDTO, User>()
                .ForMember(des => des.UserTitleId, src => src.MapFrom(u => u.UserTitleId))
                .ForMember(des => des.UserTypeId, src => src.MapFrom(u => u.UserTypeId));
        }
    }
}
