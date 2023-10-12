using System.Text.Json.Serialization;

namespace WebApi1.Models
{
    public class Author : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeEdition { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book>? Books { get; set; }        

    }
}
