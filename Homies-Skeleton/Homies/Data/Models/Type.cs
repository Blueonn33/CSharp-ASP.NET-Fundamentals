using System.ComponentModel.DataAnnotations;
using static Homies.Common.EntityValidation;

namespace Homies.Data.Models
{
    public class Type
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [StringLength(TypeNameMaxLength, MinimumLength = TypeNameMinLength)]
        public string Name
        {
            get;
            set;
        } = null!;

        public virtual ICollection<Event> Events
        {
            get;
            set;
        } = new List<Event>();
    }
}
