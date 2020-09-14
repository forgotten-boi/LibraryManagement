using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibMS.Entity.Entities;
using LibMS.Services.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IActionResult> Get()
        {
            try
            {
                var bookList=  await _bookService.GetCurrentBookAsync();
                
                return new OkObjectResult(bookList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [Route("{id}/book")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var bookList = await _bookService.FindByAsync(p => p.ID == id);

                return new OkObjectResult(bookList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
