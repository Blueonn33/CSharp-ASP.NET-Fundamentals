namespace BookVerse.Services.Data.Book.Request
{
    public class AddToMyBooksRequestData
    {
        public int BookId
        {
            get; set;
        }

        public string UserId { get; set; } = null!;
    }
}
