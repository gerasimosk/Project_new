using System.Collections.Generic;
using WebAPI.Domain;
using WebAPI.Repositories;

namespace WebAPI.Services.Implementations
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository ?? throw new System.ArgumentNullException(nameof(userTypeRepository));
        }

        public List<UserType> GetUserType()
        {
            return _userTypeRepository.GetUserType();
        }
    }
}
