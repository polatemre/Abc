using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; } //Bire çok ilişki. 5 numaralı kategorinin içindeyken Products dediğimde bütün ürünler gelicek. bir ürünün bir kategorisi var.

    }
}