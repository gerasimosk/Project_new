using AutoMapper;
using WebAPI.Domain;
using WebAPI.Services.DTOs;

namespace WebAPI.Services.Mappings
{
    public class UserTitleMappingProfile : Profile
    {
        public UserTitleMappingProfile()
        {
            EntityToDTO();
        }

        private void EntityToDTO()
        {
            CreateMap<UserTitle, UserTitleDTO>();
        }
    }
}
