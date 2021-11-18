using WebAPI.Domain;

namespace WebAPI.Repositories.Implementations
{
    public class UserTitleRepository : Repository<UserTitle>, IUserTitleRepository
    {
        public UserTitleRepository(Context context) : base(context)
        {
        }
    }
}
