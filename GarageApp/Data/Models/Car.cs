using GarageApp.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Range(CarProductionMonthMinValue, CarProductionMonthMaxValue)]
        public int? ProductionMonth
        {
            get; set;
        }

        [Range(CarYearMinValue, 2100)]
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

        [ForeignKey(nameof(Garage))]
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
