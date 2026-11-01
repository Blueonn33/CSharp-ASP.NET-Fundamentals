using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace MyBlog.ModelBinders
{
    public class DateTimeModelBinder : IModelBinder
    {
        private readonly string _dateFormat;

        public DateTimeModelBinder(string dateFormat)
        {
            _dateFormat = dateFormat;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !string.IsNullOrEmpty(valueResult.FirstValue))
            {
                string dateValue = valueResult.FirstValue;

                if (DateTime.TryParseExact(dateValue, _dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                        out DateTime parsedDate))
                {
                    bindingContext.Result = ModelBindingResult.Success(parsedDate);
                }
                else if (DateTime.TryParse(dateValue, new CultureInfo("bg-BG"), DateTimeStyles.None,
                             out parsedDate))
                {
                    bindingContext.Result = ModelBindingResult.Success(parsedDate);
                }
                else
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, $"Invalid date format. Expected format: {_dateFormat}");
                }
            }

            return Task.CompletedTask;
        }
    }
}
