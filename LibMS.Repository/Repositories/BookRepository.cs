using LibMS.DataAccess;
using LibMS.Entity.Entities;

namespace LibMS.Repository.Repositories
{
    public class BookRepository : Repository<BookInfo, int>, IBookRepository
    {
        public BookRepository(ProjectDbContext context) : base(context)
        {

        }
    }
}