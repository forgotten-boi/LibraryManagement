using LibMS.Entity.Entities;
using LibMS.Repository;
using LibMS.Repository.Repositories;
using LibMS.Services.IServices;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LibMS.Services.Services
{
    public class BookService : ApplicationService<BookInfo, int>, IBookService
    {
        public BookService(IBookRepository BookRepository) : base(BookRepository)
        {

        }

        public async Task<IEnumerable<BookInfo>> GetCurrentBookAsync()
        {
            var currentBook = await Repository.TableAsNoTracking.Where(p => p.BookCountInfo != null &&
                                              p.BookCountInfo.BookCount > 0).ToListAsync();
            return currentBook;
        }
    }
}