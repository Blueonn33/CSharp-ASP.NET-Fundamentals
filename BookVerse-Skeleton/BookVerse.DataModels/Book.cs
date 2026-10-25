using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BookVerse.GCommon.ValidationConstants.Book;

namespace BookVerse.DataModels
{
    public class Book
    {
        public int Id { get; set; }

        [Required, StringLength(TitleMax, MinimumLength = TitleMin)]
        public string Title { get; set; } = null!;

        [Required, StringLength(DescriptionMax, MinimumLength = DescriptionMin)]
        public string Description { get; set; } = null!;

        public string? CoverImageUrl { get; set; }

        [Required]
        public string PublisherId { get; set; } = null!;

        [ForeignKey(nameof(PublisherId))]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        public DateTime PublishedOn { get; set; }

        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public ICollection<UserBook> UsersBooks { get; set; } = new HashSet<UserBook>();
    }
}
