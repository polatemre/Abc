using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abc.MvcWebUI.Entity;

namespace Abc.MvcWebUI.Models
{
    public class Cart //Alışveriş sepetinin tamamını temsil ediyor.
    {
        private List<CartLine> _cartLines = new List<CartLine>(); //Her bir satırı toplayacağımız bir cart oluşturuyoruz. Sınıfa özel liste.

        public List<CartLine> CartLines //Dışarıya listeyi açmak için oluşturuyoruz.
        {
            get { return _cartLines; }
        }

        public void AddProduct(Product product, int quantity) //
        {
            var line = _cartLines.FirstOrDefault(i => i.Product.Id == product.Id); //Eklenmek istenen ürün, ürün listemizde var mı?
            if (line == null) //Eğer sepette o ürün yok ise oluştur.
            {
                _cartLines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else //Eğer sepette o ürün var ise adet kadar arttır.
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteProduct(Product product) //Ürünü sepetten sil
        {
            _cartLines.RemoveAll(i => i.Product.Id == product.Id);
        }

        public double Total() //Toplam fiyat
        {
            return _cartLines.Sum(i => i.Product.Price * i.Quantity);
        }

        public void Clear() //Sepeti temizle
        {
            _cartLines.Clear();
        }

    }

    public class CartLine //Her bir ürünü temsil eden obje, Alışveriş sepetindeki 1 satır
    {
        public Product Product { get; set; } //Ürün
        public int Quantity { get; set; } //Her bir ürünün kaç tane olduğunu tutacak.
    }
}