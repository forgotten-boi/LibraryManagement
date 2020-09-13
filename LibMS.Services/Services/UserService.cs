using Microsoft.AspNetCore.Http;
using LibMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using LibMS.Entity.Entities;
using LibMS.Entity.ViewModel;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using LibMS.Repository.Repositories;
using System.Threading.Tasks;

namespace LibMS.Services.Services
{
    public class UserService : ApplicationService<User, int>, IUserService
    {
        public UserService(IUserRepository UserRepository) : base(UserRepository)
        {

        }

        public async Task<IEnumerable<User>> GetNormalUserAsync()
        {
            var normalUser = await Repository
                                    .GetFilteredAsync(p => !string.IsNullOrEmpty(p.Password));
            return normalUser;
        }
    }
    //{
    //    private readonly IHttpContextAccessor _context;
    //    private readonly AppSettings _appSettings;
    //    public UserService(IHttpContextAccessor context, IOptions<AppSettings> appSettings)
    //    {
    //        this._context = context;
    //        _appSettings = appSettings.Value;

    //    }

    //    public string GetLoggedInUser()
    //    {
    //        var claimsIdentity = _context.HttpContext.User;
    //        var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
    //        return claim.Value.ToString();
       

    //    }

    //    //Remove Later, currently for testing
    //    private List<User> _users = new List<User>
    //    {
    //        new User { ID = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
    //    };

    //    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    //    {
    //        var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

    //        // return null if user not found
    //        if (user == null) return null;

    //        // authentication successful so generate jwt token
    //        var token = generateJwtToken(user);

    //        return new AuthenticateResponse(user, token);
    //    }

    //    public IEnumerable<User> GetAll()
    //    {
    //        return _users;
    //    }

    //    public User GetById(int id)
    //    {
    //        return _users.FirstOrDefault(x => x.ID == id);
    //    }

    //    // helper methods

    //    private string generateJwtToken(User user)
    //    {
    //        // generate token that is valid for 7 days
    //        var tokenHandler = new JwtSecurityTokenHandler();
    //        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
    //        var tokenDescriptor = new SecurityTokenDescriptor
    //        {
    //            Subject = new ClaimsIdentity(new[] { new Claim("id", user.ID.ToString()) }),
    //            Expires = DateTime.UtcNow.AddDays(7),
    //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //        };
    //        var token = tokenHandler.CreateToken(tokenDescriptor);
    //        return tokenHandler.WriteToken(token);
    //    }

    //}
}
