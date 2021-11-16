using System.Collections.Generic;
using WebAPI.Domain;

namespace WebAPI.Repositories
{
    public interface IUserTypeRepository : IRepository<UserType>
    {
        /// <summary>Gets the type of the user.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        List<UserType> GetUserType();
    }
}
