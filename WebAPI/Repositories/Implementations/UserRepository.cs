using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain;
using WebAPI.Exceptions;

namespace WebAPI.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public async Task<List<User>> GetUsersAsync(int pageNumber, int pageSize, string fullName)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("Page number and page size must be greater than zero");
            }

            return await GetAll()
                .Where(q => q.IsActive == true)
                .Where(q => (fullName != null ? (q.Name + " " + q.Surname).StartsWith(fullName) : true))

                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public override IQueryable<User> GetAll()
        {
            try
            {
                return _context.User
                    .Include(q => q.UserTitle)
                    .Include(q => q.UserType);

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("The Identity of a user cannot be zero or negative");
            }

            var entity = await GetAll()
                .Where(q => q.Id == id)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new EntityNotFoundException("Cannot find a user with the given identity");
            }

            return entity;
        }

        public async Task DeleteUserAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException("Cannot find a user with the given identity");
            }

            entity.IsActive = false;

            await UpdateAsync(entity);
        }
    }
}
