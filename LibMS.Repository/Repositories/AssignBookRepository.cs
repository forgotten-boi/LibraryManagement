using LibMS.DataAccess;
using LibMS.Entity.Entities;

namespace LibMS.Repository.Repositories
{
    public class AssignBookRepository : Repository<AssignBookInfo, int>, IAssignBookRepository
    {
        public AssignBookRepository(ProjectDbContext context) : base(context)
        {

        }
    }
}