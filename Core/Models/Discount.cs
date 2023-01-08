using Core.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Discount
    {
        public int BillId { get; set; }
        public int AccountId { get; set; }
        [PercentageValidationAttribute]
        public int Percentage { get; set; }
    }
    public class EmployeeDiscount : Discount
    {
        [PercentageValidationAttribute]
        public int Percentage { get; set; } = 30;
    }

    public class AffiliateDiscount : Discount
    {
        [PercentageValidationAttribute]
        public int Percentage { get; set; } = 10;
    }

}
