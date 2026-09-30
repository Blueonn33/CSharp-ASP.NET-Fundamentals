using System.ComponentModel.DataAnnotations;

namespace MvcIntro.ViewModels
{
    public class PersonViewModel
    {
        public int Id
        {
            get; set;
        }

        [Required(ErrorMessage = "Полето {0} e задължително")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Полето {0} трябва да е между {2} и {1} символа")]
        [Display(Name = "Име")]
        public string FirstName
        {
            get;
            set;
        } = null!;

        [Required(ErrorMessage = "Полето {0} e задължително")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Полето {0} трябва да е между {2} и {1} символа")]
        [Display(Name = "Фамилия")]
        public string LastName
        {
            get;
            set;
        } = null!;

        [Required(ErrorMessage = "Полето {0} e задължително")]
        [Range(3, 100)]
        [Display(Name = "Възраст")]
        public int Age
        {
            get; set;
        }
    }
}
