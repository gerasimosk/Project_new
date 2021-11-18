using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain;

namespace WebAPI.Services
{
    public interface IUserTitleService
    {
        /// <summary>Gets the user titles asynchronous.</summary>
        /// <returns>User titles.</returns>
        Task<List<UserTitle>> GetUserTitlesAsync();
    }
}
