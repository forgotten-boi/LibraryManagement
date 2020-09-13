using LibMS.Entity.Entities;
using System.Threading.Tasks;

namespace LibMS.Services.IServices
{
    public interface IAssignBookService : IApplicationService<AssignBookInfo, int>
    {
        Task<(bool status, string message)> ValidateBookAssignAsync(BookCountInfo currentBook, int userId);
    }

   
}