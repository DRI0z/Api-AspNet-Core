namespace WebApi1.Models
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public virtual Author? Author { get; set; }
    }
}
