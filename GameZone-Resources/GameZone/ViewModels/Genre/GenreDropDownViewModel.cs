namespace GameZone.ViewModels.Genre
{
    public class GenreDropDownViewModel
    {
        // ViewModel -> Data flow is from TRUSTED Server App to UNTRUSTED Client (View)
        // No Model Validation is required
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
