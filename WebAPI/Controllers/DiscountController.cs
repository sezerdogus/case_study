using Core.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Helpers;
using DataAccess.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet("GetBills")]
        public IActionResult GetBills() 
        {
            var bills = _discountService.GetBills();
            return Ok(bills);
        }

        [HttpGet("CalculateDiscount")]
        public IActionResult CalculateDiscount([FromBody] Bill bill)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var user = _discountService.GetAccountById(bill.AccountId);
            var billItems = _discountService.GetBillItems(bill.Id);
            

            if (billItems.Count > 0 && user !=null )
            {
                var totalAmount = billItems.Sum(x => x.UnitPrice);
                var amountToApplyPercentageDiscount = billItems.Where(x => x.ProductDescription != "Grocery").Sum(x => x.UnitPrice);
                var standardDiscountAmount = DiscountHelper.CalculateStandardDiscountAmount(totalAmount);
                TimeSpan dateDiff = user.AccountCreationDate - DateTime.Today;

                if (user.AccountType.TrimEnd() == "Employee")
                {
                    var discount = new EmployeeDiscount()
                    {
                        BillId = bill.Id,
                        AccountId = user.Id,
                    };
                    var result = new DiscountResult()
                    {
                        BillId = discount.BillId,
                        AccountId = discount.AccountId,
                        TotalAmount = totalAmount,
                        PayableAmount = totalAmount - standardDiscountAmount - DiscountHelper.CalculatePercentageDiscount(amountToApplyPercentageDiscount,discount.Percentage)
                    };
                    return Ok(result);
                }
                else if (user.AccountType.TrimEnd() == "Affiliate")
                {
                    var discount = new AffiliateDiscount()
                    {
                        BillId = bill.Id,
                        AccountId = user.Id,
                    };
                    var result = new DiscountResult()
                    {
                        BillId = discount.BillId,
                        AccountId = discount.AccountId,
                        TotalAmount = totalAmount,
                        PayableAmount = totalAmount - standardDiscountAmount - DiscountHelper.CalculatePercentageDiscount(amountToApplyPercentageDiscount, discount.Percentage)
                    };
                    return Ok(result);
                }
                else if (dateDiff.Days > 730)
                {
                    var discount = new Discount()
                    {
                        BillId = bill.Id,
                        AccountId = user.Id,
                    };
                    var result = new DiscountResult()
                    {
                        BillId = discount.BillId,
                        AccountId = discount.AccountId,
                        TotalAmount = totalAmount,
                        PayableAmount = totalAmount - standardDiscountAmount - DiscountHelper.CalculatePercentageDiscount(amountToApplyPercentageDiscount, 5)
                    };
                    return Ok(result);
                }
                else
                {
                    var discount = new Discount()
                    {
                        BillId = bill.Id,
                        AccountId = user.Id,
                    };
                    var result = new DiscountResult()
                    {
                        BillId = discount.BillId,
                        AccountId = discount.AccountId,
                        TotalAmount = totalAmount,
                        PayableAmount = totalAmount - standardDiscountAmount
                    };
                    return Ok(result);
                }
            }
            else
                return NotFound("Bill was not found");
        }
    }
}
