namespace EventManager.ViewModels.Events
{
    public class EventIndexViewModel
    {
        // No Model validation is required for ViewModels
        // Data direction is from TRUSTED Server (DB) to UNTRUSTED client, so no validation is needed
        public int Id
        {
            get; set;
        }

        public string Title
        {
            get; set;
        } = null!;

        public string CategoryName
        {
            get; set;
        } = null!;

        public string? Description
        {
            get; set;
        }

        public string StartDate
        {
            get; set;
        } = null!;

        public string EndDate
        {
            get; set;
        } = null!;

        public int CurrentParticipants
        {
            get; set;
        }

        public int MaxParticipants
        {
            get; set;
        }
    }
}
