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
        public string FirstName
        {
            get;
            set;
        } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string LastName
        {
            get;
            set;
        } = null!;

        [Required]
        [Range(3, 100)]
        public int Age
        {
            get; set;
        }
    }
}
