using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using LibMS.Api.Controllers;
using LibMS.Services.IServices;
using LibMS.Repository.Repositories;
using LibMS.Entity.Entities;
using Autofac.Extras.Moq;
using System.Linq;
using LibMS.DataAccess;
using Autofac;
using LibMS.Services.Services;

namespace LibMSTest
{
    
    public class BookControllerTest
    {
        [Fact]
        public async Task Get_NoCondition_ReturnsAvailableBooks()
        {
            var bookServiceMock = new Mock<IBookService>();
            var mockedBookService = bookServiceMock.Object;

            var bookController = new BookController(mockedBookService);
            var response = await bookController.Get();
            bookServiceMock.Verify(x => x.GetCurrentBookAsync());
        }

        [Fact]
        public async Task Get_BookWithCountZero_ReturnsNoBook()
        {
            using (var mock = AutoMock.GetLoose())
            {


                mock.Mock<IBookRepository>()
                    .Setup(x => x.GetFilteredAsync(p=>p.BookCountInfo.BookCount > 0))
                    .ReturnsAsync(GetEmptyBookList());

                var service = mock.Create<BookService>();

                var expected = GetEmptyBookList();
                var actual = await service.GetCurrentBookAsync();
                Assert.Equal(actual.Count(), expected.Count);
            }
        }
        [Fact]
        public async Task Get_BookWithCountGreaterThanZero_ReturnsBookList()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IBookRepository>()
                    .Setup(x => x.GetFilteredAsync(p => p.BookCountInfo.BookCount > 0))
                    .ReturnsAsync(GetSampleBooks());

                var service = mock.Create<BookService>();

                var expected = GetSampleBooks();
                var actual = await service.GetCurrentBookAsync();
                Assert.True(actual != null);
                Assert.Equal(expected.Count(),actual.Count());
                for (int i = 0; i < expected.Count(); i++)
                {
                    Assert.Equal(actual.ElementAt(i).Name, expected.ElementAt(i).Name);
                }
                     
            }
        }

        private IEnumerable<BookInfo> GetSampleBooks()
        {
            var output = new List<BookInfo>()
            {
                new BookInfo {Name = "First Sample Book", BookCountInfo = new BookCountInfo { BookCount = 10} },
                new BookInfo {Name = "Second Sample Book", BookCountInfo = new BookCountInfo { BookCount = 10}},
                new BookInfo {Name = "Third Sample Book" , BookCountInfo = new BookCountInfo { BookCount = 10}},
                new BookInfo {Name = "Fourth Sample Book", BookCountInfo = new BookCountInfo { BookCount = 0}},
            };
            return output;
        }

        private List<BookInfo> GetEmptyBookList()
        {
            var output = new List<BookInfo>();
            return output;
        }

        
      
    }
}
