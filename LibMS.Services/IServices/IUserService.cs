using LibMS.Entity.Entities;
using LibMS.Entity.ViewModel;
using LibMS.Repository;
using LibMS.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibMS.Services.Interface
{
    public interface IUserService : IApplicationService<User, int>
    {
        //string GetLoggedInUser();
        //AuthenticateResponse Authenticate(AuthenticateRequest model);
        //IEnumerable<User> GetAll();
        //User GetById(int id);
        Task<IEnumerable<User>> GetNormalUserAsync();
    }
}
