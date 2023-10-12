using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using WebApi1.Models;
using WebApi1.Services.Interfaces;

namespace WebApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("{authorId}")]
        public Author GetAuthorById(int authorId)
        {
            return _authorService.GetById(authorId);
        }

        [HttpGet]
        public List<Author> GetAuthors()
        {
            return _authorService.GetAll();
        }

        [HttpPost]
        public Author CreateAuthor(Author author)
        {
            return _authorService.Create(author);
        }

        [HttpPut]
        public Author UpdateAuthor(Author author)
        {
            return _authorService.Update(author);
        }

        [HttpDelete("{authorId}")]
        public string DeleteAuthorById(int authorId)
        {
            return _authorService.DeleteById(authorId);
        }


    }
}
