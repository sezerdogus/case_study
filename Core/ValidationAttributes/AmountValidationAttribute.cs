using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ValidationAttributes
{
    public class AmountValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var item = validationContext.ObjectInstance as Item;

            if (item != null && item.UnitPrice>0)
            {
                    return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Amount must be greater than 0.");
            }
        }
    }
}
