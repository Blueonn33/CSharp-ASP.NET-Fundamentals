namespace BookVerse.Services.Data.Book.Response
{
    public class GetAllBooksResponseData
    {
        public int Id
        {
            get; set;
        }

        public string Title { get; set; } = null!;

        public string GenreName { get; set; } = null!;

        public string? CoverImageUrl
        {
            get; set;
        }

        public string PublisherId { get; set; } = null!;
    }
}
