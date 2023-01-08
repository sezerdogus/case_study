using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}
