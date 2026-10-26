namespace BookVerse.Services.Data.Book.Request
{
    public class AddNewBookRequestData
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? CoverImageUrl
        {
            get; set;
        }

        public string PublisherId { get; set; } = null!;

        public DateTime PublishedOn
        {
            get; set;
        }

        public int GenreId
        {
            get; set;
        }
    }
}
