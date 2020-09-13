using LibMS.DataAccess;
using LibMS.Entity.Entities;

namespace LibMS.Repository.Repositories
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(ProjectDbContext context) : base(context)
        {

        }
    }
}