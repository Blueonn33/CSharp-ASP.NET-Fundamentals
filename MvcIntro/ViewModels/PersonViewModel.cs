using System.ComponentModel.DataAnnotations;

namespace MvcIntro.ViewModels
{
    public class PersonViewModel
    {
        public int Id
        {
            get; set;
        }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public required string FirstName
        {
            get;
            set;
        }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public required string LastName
        {
            get;
            set;
        }

        [Required]
        [Range(3, 100)]
        public int Age
        {
            get; set;
        }
    }
}
