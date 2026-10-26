namespace BookVerse.Services.Data.Book.Request
{
    public class IsBookSavedRequestData
    {
        public int BookId
        {
            get; set;
        }

        public string UserId { get; set; } = null!;
    }
}
