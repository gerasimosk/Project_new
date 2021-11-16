using System.Collections.Generic;
using WebAPI.Domain;

namespace WebAPI.Repositories
{
    public interface IUserTitleRepository : IRepository<UserTitle>
    {
        /// <summary>Gets the user title.</summary>
        /// <returns></returns>
        List<UserTitle> GetUserTitle();
    }
}
