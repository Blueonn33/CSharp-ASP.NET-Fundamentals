namespace Homies.ViewModels.Event
{
    public class EventAllViewModel
    {
        // ViewModel / Data flow is from TRUSTED Server to UNTRUSTED Client
        // No Model Validation is required
        public int Id
        {
            get; set;
        }
        public string Name { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string TypeName { get; set; } = null!;

        public string OrganizerUsername { get; set; } = null!;
    }
}
