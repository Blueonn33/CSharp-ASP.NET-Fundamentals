
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
    }
}
