using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IAuthorService _authorService;

        public BookController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        [HttpGet("{bookId}")]
        public Book GetBookById(int bookId)
        {
            return _bookService.GetById(bookId);
        }

        [HttpGet]
        public List<Book> GetBooks()
        {
            return _bookService.GetAll();
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            try
            {
                book.Author = _authorService.GetById(book.AuthorId);
                return Ok(_bookService.Create(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public Book UpdateBook(Book book)
        {
            return _bookService.Update(book);
        }

        [HttpDelete("{bookId}")]
        public string DeleteBookById(int bookId)
        {
            return _bookService.DeleteById(bookId);
        }


    }
}
