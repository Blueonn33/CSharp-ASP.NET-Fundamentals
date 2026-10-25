using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BookVerse.GCommon.ValidationConstants.Book;

namespace BookVerse.DataModels
{
    public class Book
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required, StringLength(TitleMax)]
        public string Title { get; set; } = null!;

        [Required, StringLength(DescriptionMax)]
        public string Description { get; set; } = null!;

        [StringLength(CoverImageUrlMax)]
        public string? CoverImageUrl
        {
            get; set;
        }

        public string PublisherId { get; set; } = null!;

        [ForeignKey(nameof(PublisherId))]
        public virtual IdentityUser Publisher { get; set; } = null!;

        [Column(TypeName = PublishedOnColumnType)]
        public DateTime PublishedOn
        {
            get; set;
        }

        public int GenreId
        {
            get; set;
        }

        [ForeignKey(nameof(GenreId))]
        public virtual Genre Genre { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<UserBook> UsersBooks { get; set; } = new HashSet<UserBook>();
    }
}
