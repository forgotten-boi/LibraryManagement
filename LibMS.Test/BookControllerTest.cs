using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using System.Threading.Tasks;

namespace LibMS.Test
{
    public class BookControllerTest
    {
        [Fact]
        public async Task GetAll_NoBooks_NoReturns()
        {
            var bookServiceMock = new Mock<IBookService>();
            var bookController = new BookController(bookService);
            var response = bookController.Get();
            bookServiceMock.Verify(x => x.GetCurrentBookAsync());
        }
    }
}
