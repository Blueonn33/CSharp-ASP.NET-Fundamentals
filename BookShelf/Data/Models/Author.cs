
using System.ComponentModel.DataAnnotations;
using static BookShelf.Common.EntityValidation;

namespace BookShelf.Data.Models
{
    public class Author
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [MinLength(AuthorNameMinLength)]
        [MaxLength(AuthorNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(AuthorCountryMaxLength)]
        public string? Country
        {
            get; set;
        }

        // HashSet is used for searching
        // List is used for adding
        public virtual ICollection<Book> Books
        {
            get;
            set;
        } = new HashSet<Book>();
    }
}
