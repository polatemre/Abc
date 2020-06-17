using Abc.MvcWebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abc.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext(); // contexti veritabanına bağlanmak için oluşturuyoruz.

        // GET: Home
        public ActionResult Index()
        {
            return View(_context.Products.Where(i => i.IsHome && i.IsApproved).ToList()); //Anasayfa ve onaylı olan ürünler gelsin. İndex viewe ürün listesi gönderdik.
        }

        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.Id == id).FirstOrDefault()); // Seçilen ürün idli ürün gelir
        }

        public ActionResult List()
        {
            return View(_context.Products.Where(i => i.IsApproved).ToList()); //Onaylı ürünler gelir.
        }
    }
}