using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class DiscountResult
    {
        public int BillId { get; set; }
        public int AccountId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PayableAmount { get; set; }
    }
}
