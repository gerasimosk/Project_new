using AutoMapper;
using WebAPI.Domain;
using WebAPI.Services.DTOs;

namespace WebAPI.Services.Mappings
{
    public class UserTypeMappingProfile : Profile
    {
        public UserTypeMappingProfile()
        {
            EntityToDTO();
        }

        private void EntityToDTO()
        {
            CreateMap<UserType, UserTypeDTO>();
        }
    }
}
