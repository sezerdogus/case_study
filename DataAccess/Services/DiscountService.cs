using Core.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DiscountContext _discountContext;

        public DiscountService(DiscountContext discountContext)
        {
            _discountContext = discountContext;
        }

        public Account GetAccountById(int accountId)
        {
            var account = _discountContext.Account.Find(accountId);
            return account;
        }

        public Bill GetBillById(int billId)
        {
            var bill = _discountContext.Bill.Find(billId);
            return bill;
        }

        public List<Item> GetBillItems(int billId)
        {
            var items = _discountContext.Item.Where(i=>i.BillId == billId).ToList();
            return items;
        }

        public List<Bill> GetBills()
        {
            var bills = _discountContext.Bill.Where(i => i.Id != 0).ToList();
            return bills;
        }
    }
}
