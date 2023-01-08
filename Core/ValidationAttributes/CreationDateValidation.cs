using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ValidationAttributes
{
    public class CreationDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var account = validationContext.ObjectInstance as Account;

            if (account != null && account.AccountCreationDate < DateTime.Now)
            {
                    return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid date");
            }
        }
    }
}
