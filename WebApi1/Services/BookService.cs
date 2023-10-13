using Microsoft.EntityFrameworkCore;
using WebApi1.Context;
using WebApi1.Models;
using WebApi1.Services.Interfaces;

namespace WebApi1.Services
{
    public class BookService : Service<Book>, IBookService
    {
        private readonly ApplicationDbContext _context;
        public BookService(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooksByAuthorId(int authorId)
        {
            return await _context.Books.Where(b => b.AuthorId == authorId).ToListAsync();
        }
    }
}
