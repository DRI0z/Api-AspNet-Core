using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.AccessControl;
using WebApi1.Models;
using WebApi1.Services.Interfaces;

namespace WebApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            try
            {
                return Ok(await _bookService.GetById(bookId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetBooksByAuthorId(int authorId)
        {
            try
            {
                return Ok(await _bookService.GetBooksByAuthorId(authorId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                return Ok(await _bookService.GetAll());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book)
        {
            try
            {
                return Ok(await _bookService.Create(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            try
            {
                return Ok(await _bookService.Update(book));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBookById(int bookId)
        {
            try
            {
                return Ok(await _bookService.DeleteById(bookId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
