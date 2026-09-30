using EventManager.ViewModels.Category;
using System.ComponentModel.DataAnnotations;
using static EventManager.Common.EntityValidation.Event;

namespace EventManager.ViewModels.Events
{
    public class EventInputModel : IValidatableObject
    {
        // Model Validation is required in the InputModel
        // Data direction is UNTRUSTED Client to TRUSTED Server (DB), so we need to validate the data below publishing data to server

        // Data direction Client -> Server Properties / Start
        [Required(ErrorMessage = "Event title is required")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "Event title must be between {1} and {0}")]
        public string Title
        {
            get; set;
        } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string? Description
        {
            get; set;
        }

        public DateTime StartDate
        {
            get; set;
        }

        public DateTime EndDate
        {
            get; set;
        }

        [Range(MaxParticipantsMinValue, MaxParticipantsMaxValue)]
        public int MaxParticipants
        {
            get; set;
        }

        public int CategoryId
        {
            get; set;
        }
        // Data direction Client -> Server Properties / End

        // Data direction Server -> Client Properties / Start
        public IEnumerable<CategoryDropdownViewModel> AllCategories
        {
            get; set;
        } = new List<CategoryDropdownViewModel>();
        // Data direction Server -> Client Properties / End
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate)
            {
                yield return new ValidationResult(
                    "Start date must be earlier than or equal to the end date",
                    new[] { nameof(StartDate), nameof(EndDate) });
            }
        }
    }
}
