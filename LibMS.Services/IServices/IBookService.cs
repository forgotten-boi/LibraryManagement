using LibMS.Entity.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibMS.Services.IServices
{
    public interface IBookService : IApplicationService<BookInfo, int>
    {
        Task<IEnumerable<BookInfo>> GetCurrentBookAsync();
    }
}