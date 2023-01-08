using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helpers
{
    public static class DiscountHelper
    {
        public static int CalculateStandardDiscountAmount(decimal totalAmount)
        {
            return ((int)Math.Floor(totalAmount / 100)) * 5;
        }

        public static decimal CalculatePercentageDiscount(decimal amountToApplyPercentageDiscount, int percentage)
        {
            return (amountToApplyPercentageDiscount * percentage) / 100;
        }
    }
}
