using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<UserTitle> GetUserTitle()
        {
            return _userTitleRepository.GetUserTitle();
        }
    }
}
