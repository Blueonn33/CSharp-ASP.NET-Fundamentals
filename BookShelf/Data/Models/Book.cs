using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BookShelf.Common.EntityValidation;

namespace BookShelf.Data.Models
{
    public class Book
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [MinLength(BookTitleMinLength)]
        [MaxLength(BookTitleMaxLength)]
        public string Title { get; set; } = null!;

        public int Year
        {
            get; set;
        }

        [ForeignKey(nameof(Author))]
        public int AuthorId
        {
            get; set;
        }

        public virtual Author Author { get; set; } = null!;
    }
}
