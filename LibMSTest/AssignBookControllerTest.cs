using Autofac.Extras.Moq;
using LibMS.Api.Controllers;
using LibMS.Entity.Entities;
using LibMS.Services.Interface;
using LibMS.Services.IServices;
using LibMS.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using LibMS.Repository.Repositories;
using Microsoft.AspNetCore.SignalR;
using LibMS.Api.Models;

namespace LibMSTest
{
    public class AssignBookControllerTest
    {

        [Fact]
        public async Task ValidateBookAssignAsync_BookCountGreaterThanZero_ReturnFalse()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var sampleAssignBook = new BookCountInfo
                {
                    BookCount = 3,
                    BookID = 4
                };
                var userId = 4;

                mock.Mock<IAssignBookRepository>()
                    .Setup(x => x.GetFilteredAsync(p => p.UserID == userId && p.IsReturned == false))
                    .ReturnsAsync(SampleAssignInfo());



                var service = mock.Create<AssignBookService>();

                var actual = await service.ValidateBookAssignAsync(sampleAssignBook, userId);
                Assert.True(!actual.status);

            }
        }
            [Fact]
            public async Task ValidateBookAssignAsync_BookCountLessThanZero_ReturnTrue()
            {
                using (var mock = AutoMock.GetLoose())
                {
                    var sampleAssignBook = new BookCountInfo
                    {
                        BookCount = 5,
                        BookID = 4
                    };
                    var userId = 4;

                    mock.Mock<IAssignBookRepository>()
                        .Setup(x => x.GetFilteredAsync(p => p.UserID == userId && p.IsReturned == false))
                        .ReturnsAsync(SampleValidAssign());

                    var service = mock.Create<AssignBookService>();

                    var actual = await service.ValidateBookAssignAsync(sampleAssignBook, userId);
                    Assert.True(actual.status);

                }
            }
        [Fact]
        public async Task ValidateBookAssignAsync_SameBookAssign_ReturnFalse()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var sampleAssignBook = new BookCountInfo
                {
                    BookCount = 5,
                    BookID = 4
                };
                var userId = 4;

                mock.Mock<IAssignBookRepository>()
                    .Setup(x => x.GetFilteredAsync(p => p.UserID == userId && p.IsReturned == false))
                    .ReturnsAsync(SameBookSample());

                var service = mock.Create<AssignBookService>();

                var actual = await service.ValidateBookAssignAsync(sampleAssignBook, userId);
                Assert.True(!actual.status);

            }
        }
        [Fact]
        public async Task AssignBook_InValidBook_Failed()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var currentBook = SampleBookCount();
                var assignBook = SampleValidAssign().FirstOrDefault();

                mock.Mock<IBookCountService>()
                    .Setup(x => x.FindByAsync(p => p.BookID == assignBook.BookID))
                    .ReturnsAsync(currentBook);

                mock.Mock<IAssignBookService>()
                    .Setup(x => x.ValidateBookAssignAsync(currentBook, assignBook.UserID))
                    .ReturnsAsync(SampleAssignFailureMessage());

                var service = mock.Create<AssignBookController>();

                var actual = await service.PostAsync(assignBook);
                var expected = new ResponseViewModel
                {
                    IsSuccess = false,
                    Message = "Book Assigned Failed"
                };

                Assert.Equal(actual.IsSuccess, expected.IsSuccess);

            }
        }
        [Fact]
        public async Task AssignBook_ValidBook_Success()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var currentBook = SampleBookCount();
                var assignBook = SameBookAssign();

                mock.Mock<IBookCountService>()
                    .Setup(x => x.FindByAsync(p => p.BookID == assignBook.BookID))
                    .ReturnsAsync(currentBook);

                mock.Mock<IAssignBookService>()
                     .Setup(x => x.ValidateBookAssignAsync(currentBook, assignBook.UserID))
                     .ReturnsAsync(SampleAssignSuccessMessage());

            

             

                var service = mock.Create<AssignBookController>();

                var actual =await service.PostAsync(assignBook);
                var expected = new ResponseViewModel
                {
                    IsSuccess = true,
                    Message = "Book Assigned Succesfully"
                };

                Assert.Equal(actual.IsSuccess, expected.IsSuccess);

            }
        }
        [Fact]
        public async Task ReturnBook_ValidBook_Success()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var currentBook = SampleBookCount();
                var assignBook = SameBookAssign();

                mock.Mock<IBookCountService>()
                    .Setup(x => x.FindByAsync(p => p.BookID == assignBook.BookID))
                    .ReturnsAsync(currentBook);

                mock.Mock<IAssignBookService>()
                     .Setup(x => x.FindByAsync(p => p.BookID == assignBook.BookID
                                            && p.UserID == assignBook.UserID && p.IsReturned == false))
                     .ReturnsAsync(assignBook);

                var service = mock.Create<AssignBookController>();

                var actual =await service.PutAsync(assignBook.ID, assignBook);
                var expected = new ResponseViewModel
                {
                    IsSuccess = true,
                    Message = "Book is returned",
                    Data = currentBook.BookCount + 1
                };

                Assert.Equal(actual.IsSuccess, expected.IsSuccess);
                Assert.Equal(Convert.ToInt16(actual.Data), Convert.ToInt16(expected.Data));

            }
        }
        public IEnumerable<AssignBookInfo> SampleAssignInfo()
        {
            return new List<AssignBookInfo>()
            {
                new AssignBookInfo {UserID = 4, BookID =1, IsReturned = false },
                new AssignBookInfo {UserID = 4, BookID =2, IsReturned = false },
                new AssignBookInfo {UserID = 4, BookID =3, IsReturned = false },
                new AssignBookInfo {UserID = 5, BookID =1, IsReturned = true }
            };

        }
        public IEnumerable<AssignBookInfo> SampleValidAssign()
        {
            return new List<AssignBookInfo>()
            {
                new AssignBookInfo {UserID = 4, BookID =1, IsReturned = true }
            };

        }

        public AssignBookInfo SameBookAssign()
        {
            return new AssignBookInfo
            {
                UserID = 4, BookID =5
            };

        }
        public IEnumerable<AssignBookInfo> SameBookSample()
        {
            return new List<AssignBookInfo>()
            {
                new AssignBookInfo {UserID = 4, BookID =4, IsReturned = true }
            };

        }
        public (bool status, string message) SampleAssignSuccessMessage()
        {
            return (true, string.Empty);
        }
        public (bool status, string message) SampleAssignFailureMessage()
        {
            return (false, string.Empty);
        }

        public BookCountInfo SampleBookCount()
        {
            return  new BookCountInfo
            {
                BookCount = 5,
                BookID = 5
            };
        }



    }
}
