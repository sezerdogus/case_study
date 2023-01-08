using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.ValidationAttributes;

namespace Core.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [AmountValidation]
        public decimal UnitPrice { get; set; }
        public string ProductType { get; set; }
        
    }
}
