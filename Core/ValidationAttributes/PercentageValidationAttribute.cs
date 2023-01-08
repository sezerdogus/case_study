using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ValidationAttributes
{
    public class PercentageValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var discount = validationContext.ObjectInstance as Discount;

            if (discount != null && discount.Percentage > 0)
            {
                    return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Percentage cant be negative.");
            }
        }
    }
}
