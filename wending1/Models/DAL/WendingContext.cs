using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace wending1.Models.DAL
{
    public class WendingContext : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<UserWallets> User { get; set; }
        public DbSet<Cells> Cells { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}