namespace GameZone.ViewModels.Game
{
    public class GameAllViewModel
    {
        // ViewModel -> Data flow is from Server App (TRUSTED) to Client (UNTRUSTED)
        // No need for Data Validation in ViewModel
        public int Id { get; set; }

        public string? ImageUrl
        {
            get; set;
        }

        public string Title { get; set; } = null!;

        public string GenreName { get; set; } = null!;

        // Formatted Release Date
        public string ReleasedOn { get; set; } = null!;

        public string Publisher { get; set; } = null!;
    }
}
