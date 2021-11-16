using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain;

namespace WebAPI.Repositories.Implementations
{
    public class UserTitleRepository : Repository<UserTitle>, IUserTitleRepository
    {
        public UserTitleRepository(Context context) : base(context)
        {
        }

        public List<UserTitle> GetUserTitle()
        {
            return GetAll().ToList();
        }

        public override IQueryable<UserTitle> GetAll()
        {
            try
            {
                return _context.UserTitle;

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
    }
}
