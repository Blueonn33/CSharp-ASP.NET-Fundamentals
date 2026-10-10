using Homies.ViewModels.Type;
using System.ComponentModel.DataAnnotations;
using static Homies.Common.EntityValidation;

namespace Homies.ViewModels.Event
{
    public class EventInputModel
    {
        // Input Model: Data flow is from UNTRUSTED Client to TRUSTED Server
        // Model Validation is REQUIRED
        [Required]
        [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength)]
        public string Description { get; set; } = null!;

        public DateTime Start
        {
            get; set;
        }
        public DateTime End
        {
            get; set;
        }

        public int TypeId
        {
            get; set;
        }

        // ViewModel embedded in the InputModel
        public IEnumerable<TypeDropdownViewModel> Types
        {
            get;
            set;
        } = new List<TypeDropdownViewModel>();
    }
}
