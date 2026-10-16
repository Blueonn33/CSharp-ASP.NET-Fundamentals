namespace Homies.DTO.Event
{
    public class EventDetailsViewModel : EventShortViewModel
    {
        public string End { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CreatedOn { get; set; } = null!;
    }
}
