namespace BookVerse.ViewModels.ReadingList
{
    public class BookMyBooksViewModel
    {
        public int Id
        {
            get; set;
        }

        public string Title { get; set; } = null!;

        public string? CoverImageUrl
        {
            get; set;
        }

        public string Genre { get; set; } = null!;
    }
}
