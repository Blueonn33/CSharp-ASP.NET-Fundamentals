using System.ComponentModel.DataAnnotations;
using BookVerse.ViewModels.Genre;
using static BookVerse.GCommon.ValidationConstants.Book;

namespace BookVerse.ViewModels.Book
{
    public class BookCreateInputModel
    {
        // Input Model -> Validation Required
        [Required]
        [StringLength(TitleMax, MinimumLength = TitleMin)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMax, MinimumLength = DescriptionMin)]
        public string Description { get; set; } = null!;

        [StringLength(CoverImageUrlMax)]
        public string? CoverImageUrl
        {
            get; set;
        }

        public DateTime PublishedOn
        {
            get; set;
        }

        public int GenreId
        {
            get; set;
        }

        // View Model -> No Validation Required

        public IEnumerable<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
    }
}
