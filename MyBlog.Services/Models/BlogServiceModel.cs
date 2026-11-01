using MyBlog.Services.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Services.Models
{
    public class BlogServiceModel : IValidatableObject
    {
        public int Id
        {
            get; set;
        }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title
        {
            get; set;
        } = null!;

        [StringLength(500)]
        public string? Description
        {
            get; set;
        }

        public DateTime PublishDate
        {
            get; set;
        }

        [Required]
        public DateTime ValidFrom
        {
            get; set;
        }

        [Required]
        [IsAfter(nameof(ValidFrom), ErrorMessage = "ValidTo must be after ValidFrom")]
        public DateTime ValidTo
        {
            get; set;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PublishDate.Date > DateTime.Now.Date)
            {
                yield return new ValidationResult("PublishDate cannot be in the future", [nameof(PublishDate)]);
            }
        }
    }
}
