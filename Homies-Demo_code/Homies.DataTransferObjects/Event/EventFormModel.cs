using Homies.DataTransferObjects.Type;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Homies.GCommon.Constants.DataConstants;

namespace Homies.DataTransferObjects.Event
{
    public class EventFormModel
    {

        [Required]
        [StringLength(EventMaxName, MinimumLength = EventMinName,
            ErrorMessage = "Event name must be between 5 and 20 characters.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(EventMaxDescription, MinimumLength = EventMinDescription,
            ErrorMessage = "Description must be between 15 and 150 characters.")]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required] 
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; }
            = new List<TypeViewModel>();
    }
}
