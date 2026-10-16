using Homies.DTO.Type;
using System.ComponentModel.DataAnnotations;
using static Homies.GCommon.Constants.EntityValidation;

namespace Homies.DTO.Event
{
    public class EventInputModel
    {
        [Required]
        [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength, ErrorMessage = "Event must be between {2} and {1} characters")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength, ErrorMessage = "Description must be between {2} and {1} characters")]
        public string Description { get; set; } = null!;

        public int TypeId
        {
            get; set;
        }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();

        public DateTime Start
        {
            get; set;
        }

        public DateTime End
        {
            get; set;
        }
    }
}
