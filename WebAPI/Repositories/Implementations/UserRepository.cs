using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain;

namespace WebAPI.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public async Task<List<User>> GetUsersAsync(int pageNumber, int pageSize, string fullName)
        {
            return await GetAll()
                .Where(q => q.IsActive == true)
                .Where(q => (fullName != null ? (q.Name + " " + q.Surname).StartsWith(fullName) : true))

                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var entity = await GetAll()
                .Where(q => q.Id == id)
                .FirstOrDefaultAsync();

            return entity;
        }

        public async Task<int> GetUsersCountAsync(string fullName)
        {
            return await GetAll()
                .Where(q => q.IsActive == true)
                .Where(q => (fullName != null ? (q.Name + " " + q.Surname).StartsWith(fullName) : true))
                .CountAsync();
        }

        private IQueryable<User> GetAll()
        {
            return _context.User
                .Include(q => q.UserTitle)
                .Include(q => q.UserType);
        }
    }
}
