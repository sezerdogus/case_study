using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public interface IDiscountService
    {
        Account GetAccountById(int accountId);
        Bill GetBillById(int billId);

        List<Item> GetBillItems(int billId);
        List<Bill> GetBills();
    }
}
