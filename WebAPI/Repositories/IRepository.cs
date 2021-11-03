using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>Gets all entities asynchronous.</summary>
        /// <returns>All entities</returns>
        Task<List<TEntity>> GetAllAsync();

        /// <summary>Gets all entities.</summary>
        /// <returns>All entities</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>Gets an entity by identifier asynchronous.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A selected entity</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>Adds the given entity asynchronously.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The added entity</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>Updates the given entity asynchronous.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The updated entity</returns>
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
