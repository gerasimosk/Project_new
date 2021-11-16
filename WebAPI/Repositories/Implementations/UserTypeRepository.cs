using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Domain;

namespace WebAPI.Repositories.Implementations
{
    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(Context context) : base(context)
        {
        }

        public List<UserType> GetUserType()
        {
            return GetAll().ToList();
        }

        public override IQueryable<UserType> GetAll()
        {
            try
            {
                return _context.UserType;

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
    }
}
