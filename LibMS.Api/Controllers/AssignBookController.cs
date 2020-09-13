using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibMS.Api.Models;
using LibMS.Entity.DtoModel;
using LibMS.Entity.Entities;
using LibMS.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LibMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignBookController : ControllerBase
    {
        IAssignBookService _assignBookService;
        IBookCountService _bookCountService;
        public AssignBookController(IAssignBookService assignBookService, IBookCountService bookCountService)
        {
            _assignBookService = assignBookService;
            _bookCountService = bookCountService;
        }

        

        [HttpPost]
        public async Task<ResponseViewModel> PostAsync([FromBody] AssignBookInfo assignBook)
        {
            try
            {
                var response = new ResponseViewModel();
                var currentBook = await _bookCountService.FindByAsync(p => p.BookID == assignBook.BookID);
                var validation = await _assignBookService.ValidateBookAssignAsync(currentBook, assignBook.UserID);
                if (validation.status)
                {
                    assignBook.CreatedDate = DateTime.Now;
                    currentBook.CreatedDate = DateTime.Now;
                    await _assignBookService.AddAsync(assignBook);
                    currentBook.BookCount = currentBook.BookCount - 1;
                    await _bookCountService.UpdateAsync(currentBook);
                    response =  new ResponseViewModel
                    {
                        IsSuccess = true,
                        Message = "Book Assigned Succesfully"
                    };
                    return response;
                }
                response = new ResponseViewModel
                {
                    IsSuccess = false,
                    Message = validation.message
                };
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/<AssignBookController>/5
        [HttpPut("{id}/return")]
        public async Task<ResponseViewModel> PutAsync(int id, [FromBody] AssignBookInfo assignBook)
        {
            try
            {
                var currentBook = await _bookCountService.FindByAsync(p => p.BookID == assignBook.BookID);
                currentBook.BookCount += 1;
                var assignedBook = await _assignBookService.FindByAsync(p => p.BookID == assignBook.BookID
                                                && p.UserID == assignBook.UserID && p.IsReturned == false);
                assignedBook.IsReturned = true;
                assignedBook.ModifiedDate = DateTime.Now;
                currentBook.ModifiedDate = DateTime.Now;
                await _bookCountService.UpdateAsync(currentBook);
                await _assignBookService.UpdateAsync(assignedBook);
                return new ResponseViewModel
                {
                    IsSuccess = true,
                    Message = "Book is returned",
                    Data = currentBook.BookCount
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
