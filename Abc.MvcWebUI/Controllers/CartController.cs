using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abc.MvcWebUI.Entity;
using Abc.MvcWebUI.Models;

namespace Abc.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private DataContext _db = new DataContext();

        // Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        // Add
        public ActionResult AddToCart(int Id)
        {
            var product = _db.Products.FirstOrDefault(i => i.Id == Id); // Eğer ürün var ise ekleme yapılabilir.

            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("Index"); //View göndermedik çünkü AddToCart göndermemiz gerekirdi.
        }

        // Remove
        public ActionResult RemoveFromCart(int Id)
        {
            var product = _db.Products.FirstOrDefault(i => i.Id == Id); // Eğer ürün var ise ekleme yapılabilir.

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index"); //View göndermedik çünkü AddToCart göndermemiz gerekirdi.
        }

        // GetCart
        public Cart GetCart()
        {
            //Session her kullanıcıya özel oluşturulan bir alandır.
            var cart = (Cart)Session["Cart"]; //Yeni bir kişi siteyi ziyaret ettiğinde ona carttan yeni bir tane oluşturup göndericez.

            if (cart == null) //nulla eşitse session içerisine bir eleman atılmamış demektir.
            {
                cart = new Cart(); //Yeni bir kopya oluşturup cart'a atıyoruz.
                Session["Cart"] = cart; //Daha sonra session içerisinde saklıyoruz. Yeni session oluşturmayacaz.
            }

            return cart;
        }

        // Summary
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        // GET: Checkout
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        // POST: Checkout
        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            { //Eğer alışverişi tamamla butonuna bir ürün olmadan basarsa bu mesaj karşısına çıkacak.
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            { //Form eksiksiz olarak dolduruldu demektir eğer buraya geldiyse. Requiredlar doğru doldurulmuş
                //Siparişi veritabanına kayıt et.
                //Ardından cart'ı sıfırla

                SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed");
            }
            else
            {// Eğer isvalid değil ise hata varsa.
                return View(entity);
            }



        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();

            order.OrderNumber = "A" + (new Random()).Next(11111, 99999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;

            order.Username = entity.Username;
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            order.OrderLines = new List<OrderLine>();

            foreach (var pr in cart.CartLines)
            {
                OrderLine _orderLine = new OrderLine();
                _orderLine.Quantity = pr.Quantity;
                _orderLine.Price = pr.Quantity * pr.Product.Price;
                _orderLine.ProductId = pr.Product.Id;

                order.OrderLines.Add(_orderLine);
            }

            _db.Orders.Add(order);
            _db.SaveChanges();

        }
    }
}