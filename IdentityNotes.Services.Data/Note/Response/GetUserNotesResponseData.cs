namespace IdentityNotes.Services.Data.Note.Response
{
    public class GetUserNotesResponseData
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
    }
}
