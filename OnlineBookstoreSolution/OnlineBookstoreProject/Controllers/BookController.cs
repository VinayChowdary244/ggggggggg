using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreProject.Exceptions;
using OnlineBookstoreProject.Interfaces;
using OnlineBookstoreProject.Models;
using OnlineBookstoreProject.Models.DTOs;
using OnlineBookstoreProject.Services;
using Microsoft.AspNetCore.Cors;
using OnlineBookStore.Models.DTOs;
namespace OnlineBookstoreProject.Controllers
{
    [Route("api/[controller]")] 
    [ApiController] 
    [EnableCors("reactApp")] 
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService; 
        private readonly ILogger<BookController> _logger; 

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]  
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookService.GetBooks();  
                return Ok(result); 
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage); 
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Book book)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookService.Add(book); 
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage); 
        }

        [Authorize(Roles = "Admin")]
        [Route("DeleteBook")]
        [HttpDelete]
        public ActionResult DeleteBook(BookIdDTO bookIdDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookService.RemoveBook(bookIdDTO); 
                return Ok(result); 
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage); 
        }

        [Authorize(Roles = "Admin")]
        [Route("UpdateBook")]
        [HttpPut]
        public ActionResult UpdateBook(UpdateBookDTO bookDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookService.UpdateBook(bookDTO); 
                return Ok(result);  
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);  
        }

        [HttpPost]
        [Route("GetBookById")]
        public ActionResult GetBookById(BookIdDTO bookIdDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookService.GetBookById(bookIdDTO);

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }

    }

}