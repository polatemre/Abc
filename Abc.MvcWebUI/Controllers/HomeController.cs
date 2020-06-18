using Abc.MvcWebUI.Entity;
using Abc.MvcWebUI.Models;
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
            var urunler = _context.Products
                                  .Where(i => i.IsHome && i.IsApproved)
                                  .Select(i => new ProductModel()
                                  { //Veritabanından gelen verileri ProductModel nesnemize ekliyoruz.
                                      Id = i.Id,
                                      Name = i.Name.Length > 45 ? i.Name.Substring(0, 45) + "..." : i.Name,
                                      Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                                      Price = i.Price,
                                      Stock = i.Stock,
                                      Image = i.Image ?? "1.jpg",
                                      CategoryId = i.CategoryId

                                  }).ToList();

            return View(urunler); //İndex viewe ürün listesi gönderdik.
        }

        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.Id == id).FirstOrDefault()); // Seçilen ürün idli ürün gelir
        }

        public ActionResult List(int? id) //int? dedik yani parametre zorunlu değil. Kategori idsi
        {
            var urunler = _context.Products
                                     .Where(i => i.IsApproved)
                                     .Select(i => new ProductModel()
                                     { //Veritabanından gelen verileri ProductModel nesnemize ekliyoruz.
                                         Id = i.Id,
                                         Name = i.Name.Length > 40 ? i.Name.Substring(0, 40) + "..." : i.Name,
                                         Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                                         Price = i.Price,
                                         Stock = i.Stock,
                                         Image = i.Image ?? "1.jpg", //Veritabanındaki image alanı boş ise 1.jpg olsun
                                         CategoryId = i.CategoryId

                                     }).AsQueryable(); // AsQueryable() yani veritabanı sorgusunu hazırladık ancak çalıştırmadık. Ekstra filtreleme ekleyeceksek kullanırız.

            if (id != null) // demekki bir id değeri girildi.
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }

            return View(urunler.ToList()); //İndex viewe ürün listesi gönderdik.
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}