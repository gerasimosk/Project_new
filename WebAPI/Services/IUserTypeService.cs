using System.Collections.Generic;
using WebAPI.Domain;

namespace WebAPI.Services
{
    public interface IUserTypeService
    {
        /// <summary>Gets the type of the user.</summary>
        /// <returns></returns>
        List<UserType> GetUserType();
    }
}
