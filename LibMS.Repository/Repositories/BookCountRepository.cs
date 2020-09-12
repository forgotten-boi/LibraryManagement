using LibMS.DataAccess;
using LibMS.Entity.Entities;

namespace LibMS.Repository.Repositories
{
    public class BookCountRepository : Repository<BookCountInfo, int>, IBookCountRepository
    {
        public BookCountRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }
}