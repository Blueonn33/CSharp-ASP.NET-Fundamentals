namespace BookVerse.Services.Data.Book.Request
{
    public class IsBookPublisherRequestData
    {
        public int BookId
        {
            get; set;
        }

        public string UserId { get; set; } = null!;
    }
}
