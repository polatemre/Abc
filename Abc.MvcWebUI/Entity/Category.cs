using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class Category
    {
        public int Id { get; set; }
        //Data annotations deniyor bunlara
        [DisplayName("Kategori Adı")]
        [StringLength(maximumLength: 20, ErrorMessage = "En fazla 20 karakter girebilirsiniz.")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        public List<Product> Products { get; set; } //Bire çok ilişki. 5 numaralı kategorinin içindeyken Products dediğimde bütün ürünler gelicek. bir ürünün bir kategorisi var.

    }
}