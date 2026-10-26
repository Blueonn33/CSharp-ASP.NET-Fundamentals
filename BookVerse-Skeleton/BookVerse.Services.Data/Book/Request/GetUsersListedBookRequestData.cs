namespace BookVerse.Services.Data.Book.Request
{
    public class GetUsersListedBookRequestData
    {
        public int BookId
        {
            get; set;
        }

        public int SkipEntries
        {
            get; set;
        }

        public int TakeEntries
        {
            get; set;
        }
    }
}
