using Microsoft.AspNetCore.Mvc;
using LibMS.Api.Models;

using LibMS.Entity.ViewModel;
using LibMS.Services.Interface;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using LibMS.Entity.Entities;

namespace LibMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpPost("authenticate")]
        //public IActionResult Authenticate(AuthenticateRequest model)
        //{
        //    var response = _userService.Authenticate(model);

        //    if (response == null)
        //        return BadRequest(new { message = "Username or password is incorrect" });

        //    return Ok(response);
        //}

        /// <summary>
        /// Returning Normal user list with no access to authentication. 
        /// Only librarian have access to authentication.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<User> users = await _userService.GetNormalUserAsync();
            return Ok(users);
        }
    }
}
