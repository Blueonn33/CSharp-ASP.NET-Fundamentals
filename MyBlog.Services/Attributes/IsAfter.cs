using System.ComponentModel.DataAnnotations;

namespace MyBlog.Services.Attributes
{
    public class IsAfter : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public IsAfter(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var comparisonValue = validationContext.ObjectType.GetProperty(_comparisonProperty)
                ?.GetValue(validationContext.ObjectInstance);

            if (value is DateTime dateTimeValue && comparisonValue is DateTime comparisonDateTime)
            {
                if (dateTimeValue <= comparisonDateTime)
                {
                    return new ValidationResult(ErrorMessage ?? $"The date must be after {_comparisonProperty}");
                }
            }

            return ValidationResult.Success;
        }
    }
}
