using System.ComponentModel.DataAnnotations;
using static GarageApp.Common.EntityValidation;

namespace GarageApp.Data.Models
{
    public class Garage
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [MinLength(GarageNameMinLength)]
        [MaxLength(GarageNameMaxLength)]
        public string Name
        {
            get; set;
        } = null!;

        [Required]
        [MinLength(GarageLocationMinLength)]
        [MaxLength(GarageLocationMaxLength)]
        public string Location
        {
            get; set;
        } = null!;

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
