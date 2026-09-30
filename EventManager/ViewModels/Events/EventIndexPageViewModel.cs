using EventManager.ViewModels.Category;

namespace EventManager.ViewModels.Events
{
    public class EventIndexPageViewModel
    {
        public IEnumerable<EventIndexViewModel> Events { get; set; } = [];

        public string? Title
        {
            get; set;
        }

        public int? CategoryId
        {
            get; set;
        }

        public DateTime? StartDate
        {
            get; set;
        }

        public DateTime? EndDate
        {
            get; set;
        }

        public IEnumerable<CategoryDropdownViewModel> Categories { get; set; } = [];
    }
}
