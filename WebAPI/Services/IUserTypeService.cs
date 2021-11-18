using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain;

namespace WebAPI.Services
{
    public interface IUserTypeService
    {
        /// <summary>Gets the user types asynchronous.</summary>
        /// <returns>User types</returns>
        Task<List<UserType>> GetUserTypesAsync();
    }
}
