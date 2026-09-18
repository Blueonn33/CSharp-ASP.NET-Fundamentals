using GarageApp.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static GarageApp.Common.EntityValidation;

namespace GarageApp.Data.Models
{
    public class Car
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [MinLength(CarMakeMinLength)]
        [MaxLength(CarMakeMaxLength)]
        public string Make
        {
            get; set;
        } = null!;

        [Required]
        [MinLength(CarModelMinLength)]
        [MaxLength(CarModelMaxLength)]
        public string Model
        {
            get; set;
        } = null!;

        public int? ProductionMonth
        {
            get; set;
        }

        public int Year
        {
            get; set;
        }

        public CarType CarType
        {
            get; set;
        }

        public bool IsAvailable
        {
            get; set;
        }

        public int GarageId
        {
            get; set;
        }

        public virtual Garage Garage
        {
            get;
            set;
        } = null!;
    }
}
