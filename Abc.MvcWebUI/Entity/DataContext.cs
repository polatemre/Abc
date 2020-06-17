using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dataConntection")
        {
            Database.SetInitializer(new DataInitializer()); // yaptığımız initializerı devreye girmesini sağlıyoruz.
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}