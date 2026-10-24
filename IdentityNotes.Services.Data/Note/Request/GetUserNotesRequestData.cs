namespace IdentityNotes.Services.Data.Note.Request
{
    public class GetUserNotesRequestData
    {
        public string UserId { get; set; } = null!;

        public int SkipEntries { get; set; }

        public int TakeEntries { get; set; }
    }
}
