using LibMS.Entity.Entities;
using LibMS.Repository;
using LibMS.Repository.Repositories;
using LibMS.Services.IServices;

namespace LibMS.Services.Services
{
    public class BookCountService : ApplicationService<BookCountInfo, int>, IBookCountService
    {
        public BookCountService(IBookCountRepository ApprovalInfoRepository) : base(ApprovalInfoRepository)
        {

        }
    }
}