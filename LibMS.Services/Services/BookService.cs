using LibMS.Entity.Entities;
using LibMS.Repository.Repositories;
using LibMS.Services.IServices;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace LibMS.Services.Services
{
    public class BookService : ApplicationService<BookInfo, int>, IBookService
    {
        IBookCountRepository _bookCountRepository;
        public BookService(IBookRepository BookRepository) : base(BookRepository)
        {
           
        }

        public async Task<IEnumerable<BookInfo>> GetCurrentBookAsync()
        {
            //var currentBook = await (from entity in Repository.TableAsNoTracking.Include(p=>p.BookCountInfo)
            //                            join bookCount in _bookCountRepository.TableAsNoTracking
            //                                    on entity.ID equals bookCount.BookID into ps
            //                            from bookCount in ps.DefaultIfEmpty()
            //                            where bookCount.BookCount > 0
            //                   select new BookInfo
            //                   {
            //                       ID = entity.ID,
            //                       Name = entity.Name,
            //                       Details = entity.Details,
            //                       CreatedBy = entity.CreatedBy,
            //                       CreatedDate = entity.CreatedDate,
            //                       BookCountInfo = bookCount
            //                   }).ToListAsync();
            var currentBook = await Repository.GetFilteredAsync(p => p.BookCountInfo.BookCount > 0);
            return currentBook;
        }
    }
}