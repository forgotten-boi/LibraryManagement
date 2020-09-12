using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibMS.Entity.Entities;
using LibMS.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LibMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;

        }

        [HttpGet]
        public async Task<IEnumerable<BookInfo>> Get()
        {
            var bookList = await _bookService.GetCurrentBookAsync();
            return bookList;
        }
    }
}
