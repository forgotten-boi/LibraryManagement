using LibMS.Entity.Entities;
using LibMS.Repository.Repositories;
using LibMS.Services.IServices;
using System.Linq;
using System.Threading.Tasks;

namespace LibMS.Services.Services
{
    public class AssignBookService : ApplicationService<AssignBookInfo, int>, IAssignBookService
    {
        public AssignBookService(IAssignBookRepository assignBookRepository) : base(assignBookRepository)
        {

        }

        public async Task<(bool status, string message)> ValidateBookAssignAsync(BookCountInfo currentBook, int userId)
        {
            if (currentBook.BookCount != 0)
            {
                var userAssignedBook = await Repository.GetFilteredAsync(p =>
                                                            p.UserID == userId
                                                            && p.IsReturned == false);
                if (userAssignedBook.Count() == 0 ||
                    (userAssignedBook.Count() < 2 &&
                    userAssignedBook.Any(p => p.BookID != currentBook.BookID)))
                {
                    return (true, "Success");
                }
                return (false, "User cannot borrow more than two books or more than one copy of same books");
            }
            return (false, "Book does not exist in the library");
        }
    }
}