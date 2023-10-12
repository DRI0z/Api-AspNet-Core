using WebApi1.Services.Interfaces;

namespace Unit_Test
{
    public class AuthorTest
    {
        private readonly IAuthorService _authorService;
        public AuthorTest(IAuthorService authorService) 
        {
            _authorService = authorService;
        }

        [Fact]
        public void GetById()
        {

        }

        [Fact]
        public void GetAll()
        {

        }

        [Fact]
        public void Add()
        {

        }

        [Fact]
        public void Update()
        {

        }

        [Fact]
        public void DeleteById()
        {

        }
    }
}