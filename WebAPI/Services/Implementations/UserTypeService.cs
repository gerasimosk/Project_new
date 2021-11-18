using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<List<UserType>> GetUserTypesAsync()
        {
            return await _userTypeRepository.GetAllAsync();
        }
    }
}
