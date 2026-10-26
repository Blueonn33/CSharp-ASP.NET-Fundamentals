namespace BookVerse.Services.Data.Book.Response
{
    public class GetUsersListedBookResponseData
    {
        public IEnumerable<string> UsersListedIds { get; set; } = new List<string>();
    }
}
