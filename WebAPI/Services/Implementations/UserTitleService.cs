using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain;
using WebAPI.Repositories;

namespace WebAPI.Services.Implementations
{
    public class UserTitleService : IUserTitleService
    {
        private readonly IUserTitleRepository _userTitleRepository;

        public UserTitleService(IUserTitleRepository userTitleRepository)
        {
            _userTitleRepository = userTitleRepository ?? throw new System.ArgumentNullException(nameof(userTitleRepository));
        }

        public async Task<List<UserTitle>> GetUserTitlesAsync()
        {
            return await _userTitleRepository.GetAllAsync();
        }
    }
}
