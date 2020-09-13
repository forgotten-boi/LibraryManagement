using Autofac.Extras.Moq;
using LibMS.Entity.Entities;
using LibMS.Repository.Repositories;
using LibMS.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibMSTest
{
    public class UserControllerTest
    {
        [Fact]
        public async Task Get_NoPassword_ReturnsUser()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IUserRepository>()
                    .Setup(x => x.GetFilteredAsync(p => !string.IsNullOrEmpty(p.Password)))
                    .ReturnsAsync(GetSampleUsers());

                var service = mock.Create<UserService>();

                var expected = GetSampleUsers();
                var actual = await service.GetNormalUserAsync();
                Assert.True(actual != null);
                Assert.Equal(expected.Count(), actual.Count());
                for (int i = 0; i < expected.Count(); i++)
                {
                    Assert.Equal(actual.ElementAt(i).Username, expected.ElementAt(i).Username);
                }

            }
        }

        private IEnumerable<User> GetSampleUsers()
        {
            return new List<User>
           {
               new User { Username = "One" },
               new User { Username = "Two" },
               new User { Username = "Three" },
               new User { Username = "One", Password = "password" },
           };
        }
    }
}
