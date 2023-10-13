using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using WebApi1.Models;
using WebApi1.Services;
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
        public async Task<IActionResult> GetAuthorById(int authorId)
        {
            try
            {
                return Ok(await _authorService.GetById(authorId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                return Ok(await _authorService.GetAll());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(Author author)
        {
            try
            {
                return Ok(await _authorService.Create(author));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(Author author)
        {
            try
            {
                return Ok(await _authorService.Update(author));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteAuthorById(int authorId)
        {
            try
            {
                return Ok(await _authorService.DeleteById(authorId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
