using Core.Models;
using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiTest
{
    public class DiscountServiceMock : IDiscountService
    {
        private readonly List<Account> _accountList;
        private readonly List<Bill> _billList;
        private readonly List<Item> _itemList;
        public DiscountServiceMock()
        {
            _accountList = new List<Account>()
            {
                new Account() { Id = 1, AccountHolderName = "Dogus", AccountHolderSurname="Sezer", AccountCreationDate = new DateTime(2019, 12, 30), AccountType = "Employee" },
                new Account() { Id = 2, AccountHolderName = "Canan", AccountHolderSurname="Sezer", AccountCreationDate = new DateTime(2006, 12, 30), AccountType = "Affiliate" },
                new Account() { Id = 1, AccountHolderName = "Devrim", AccountHolderSurname="Sezer", AccountCreationDate = new DateTime(2019, 12, 30), AccountType = "Customer" },
            };
            _billList = new List<Bill>()
            {
                new Bill() { Id = 1, AccountId = 1},
                new Bill() { Id = 2, AccountId = 1},
                new Bill() { Id = 3, AccountId = 2},
                new Bill() { Id = 4, AccountId = 2},
                new Bill() { Id = 5, AccountId = 3},
            };

            _itemList = new List<Item>()
            {
                new Item() { Id = 1, BillId = 1, ProductDescription = "Steak", UnitPrice = new decimal(250.20),  ProductType = "Butchery"},
                new Item() { Id = 2, BillId = 1, ProductDescription = "Tomato", UnitPrice = new decimal(25.18),  ProductType = "Grocery"},
                new Item() { Id = 3, BillId = 1, ProductDescription = "Lettuce", UnitPrice = new decimal(18.20),  ProductType = "Grocery"},
                new Item() { Id = 4, BillId = 1, ProductDescription = "WhiteCheese", UnitPrice = new decimal(80.85), ProductType = "Deli" },
                new Item() { Id = 5, BillId = 2, ProductDescription = "ChocolateCake", UnitPrice = new decimal(90.35), ProductType = "Patisserie" },
                new Item() { Id = 6, BillId = 2, ProductDescription = "Steak", UnitPrice = new decimal(250.20),  ProductType = "Butchery"},
                new Item() { Id = 7, BillId = 2, ProductDescription = "Tomato", UnitPrice = new decimal(25.18),  ProductType = "Grocery"},
                new Item() { Id = 8, BillId = 3, ProductDescription = "Lettuce", UnitPrice = new decimal(18.20),  ProductType = "Grocery"},
                new Item() { Id = 9, BillId = 3, ProductDescription = "WhiteCheese", UnitPrice = new decimal(80.85), ProductType = "Deli" },
                new Item() { Id = 10, BillId = 3, ProductDescription = "ChocolateCake", UnitPrice = new decimal(90.35), ProductType = "Patisserie" },
                new Item() { Id = 11, BillId = 4, ProductDescription = "Bread", UnitPrice = new decimal(4.70), ProductType = "Bakery" },
                new Item() { Id = 12, BillId = 4, ProductDescription = "WhiteCheese", UnitPrice = new decimal(80.85), ProductType = "Deli" },
                new Item() { Id = 13, BillId = 4, ProductDescription = "ChocolateCake", UnitPrice = new decimal(90.35), ProductType = "Patisserie" },
                new Item() { Id = 14, BillId = 5, ProductDescription = "ChocolateCake", UnitPrice = new decimal(90.35), ProductType = "Patisserie" },
                new Item() { Id = 15, BillId = 5, ProductDescription = "Steak", UnitPrice = new decimal(250.20),  ProductType = "Butchery"},
                new Item() { Id = 16, BillId = 5, ProductDescription = "Tomato", UnitPrice = new decimal(25.18),  ProductType = "Grocery"},
            };
        }

        public Account GetAccountById(int accountId)
        {
            return _accountList.Where(i => i.Id == accountId).FirstOrDefault();
        }

        public Bill GetBillById(int billId)
        {
            return _billList.Where(i => i.Id == billId).FirstOrDefault();
        }

        public List<Item> GetBillItems(int billId)
        {
            return _itemList.Where(i => i.BillId == billId).ToList();
        }

        public List<Bill> GetBills()
        {
            return _billList;
        }
    }
}
