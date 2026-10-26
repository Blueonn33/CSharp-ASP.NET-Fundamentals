namespace BookVerse.Services.Data.Book.Response
{
    public class GetBookDetailsResponseData
    {
        public int Id
        {
            get; set;
        }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? CoverImageUrl
        {
            get; set;
        }

        public DateTime PublishedOn { get; set; }

        public string Genre { get; set; } = null!;

        public string PublisherId { get; set; } = null!;
    }
}
