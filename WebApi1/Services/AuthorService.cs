using WebApi1.Context;
using WebApi1.Models;
using WebApi1.Services.Interfaces;

namespace WebApi1.Services
{
    public class AuthorService : Service<Author>, IAuthorService
    {
        public AuthorService(ApplicationDbContext context) : base(context) 
        {
        
        }
    }
}
