using WebApi1.Models;

namespace WebApi1.Services.Interfaces
{
    public interface IBookService : IService<Book>
    {
        Task<List<Book>> GetBooksByAuthorId(int authorId);
    }
}
