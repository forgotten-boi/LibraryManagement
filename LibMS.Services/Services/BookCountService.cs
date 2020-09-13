using LibMS.Entity.Entities;
using LibMS.Repository.Repositories;
using LibMS.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibMS.Services.Services
{
    public class BookCountService : ApplicationService<BookCountInfo, int>, IBookCountService
    {
        public BookCountService(IBookCountRepository ApprovalInfoRepository) : base(ApprovalInfoRepository)
        {

        }

        public async Task<IEnumerable<BookCountInfo>> GetCurrentBookAsync()
        {
            var currentBook = await Repository.TableAsNoTracking.Include(p=>p.BookID)
                                        .Where(p => 
                                              p.BookCount > 0)
                                        .ToListAsync();
            return currentBook;
        }
    }
}