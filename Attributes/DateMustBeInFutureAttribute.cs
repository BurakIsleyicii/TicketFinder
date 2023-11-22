using System.ComponentModel.DataAnnotations;

namespace TicketFinder.Attributes
{
    public class DateMustBeInFutureAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date && date.Date < DateTime.Now.Date)
            {
                return new ValidationResult(ErrorMessage ?? "The date cannot be before today.");
            }

            return ValidationResult.Success;
        }
    }

}
