using LibMS.Entity.Entities;
using LibMS.Repository;
using LibMS.Repository.Repositories;
using LibMS.Services.IServices;

namespace LibMS.Services.Services
{
    public class AssignBookService : ApplicationService<AssignBookInfo, int>, IAssignBookService
    {
        public AssignBookService(IAssignBookRepository assignBookRepository) : base(assignBookRepository)
        {

        }
    }
}