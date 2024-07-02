using System;
using System.ComponentModel.DataAnnotations;

public class CustomerValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("The field is required.");
        }

        if (value is string stringValue)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return new ValidationResult("The field cannot be empty or whitespace.");
            }

            if (stringValue.Length < 1 || stringValue.Length > 100)
            {
                return new ValidationResult("The field length must be between 1 and 100 characters.");
            }
        }

        return ValidationResult.Success;
    }
}
