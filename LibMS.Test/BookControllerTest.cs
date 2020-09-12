using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using System.Threading.Tasks;
using LibMS.Services.IServices;
using LibMS.Api.Controllers;

namespace LibMS.Test
{
    public class BookControllerTest
    {
        [Fact]
        public async Task Get_BooksWithBookCountGreaterThanZero_ReturnsAvailableBooks()
        {
            var bookServiceMock = new Mock<IBookService>();
            var mockedBookService = bookServiceMock.Object;

            var bookController = new BookController(mockedBookService);
            var response = await bookController.Get();
            bookServiceMock.Verify(x => x.GetCurrentBookAsync());
        }
    }
}
