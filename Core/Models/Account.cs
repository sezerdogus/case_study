using Core.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string AccountHolderName { get; set; }
        [Required]
        public string AccountHolderSurname { get; set; }
        [CreationDateValidation]
        public DateTime AccountCreationDate { get; set; }
        [Required]
        public string AccountType { get; set; }
    }
}
