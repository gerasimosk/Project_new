using WebAPI.Domain;

namespace WebAPI.Repositories.Implementations
{
    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(Context context) : base(context)
        {
        }
    }
}
