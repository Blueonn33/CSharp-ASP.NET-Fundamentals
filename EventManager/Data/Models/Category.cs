using System.ComponentModel.DataAnnotations;
using static EventManager.Common.EntityValidation.Category;

namespace EventManager.Data.Models
{
    public class Category
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name
        {
            get; set;
        } = null!;

        public virtual ICollection<Event> Events
        {
            get;
            set;
        } = new List<Event>();    // adding is more used than searching (HashSet)
    }
}
