using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Abc.MvcWebUI.Entity;

namespace Abc.MvcWebUI.Controllers
{
    //[Authorize] //giriş yapan herkes bu controle erişebilir.
    [Authorize(Roles = "admin")] //Giriş yapmış ve admin rolüne sahip ise controllera erişebilir.
    public class CategoryController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Create //[HTTPGET] yada [HTTPPOST] yazılmazsa bu default httpget olarak kabul edilir. Okuma işlemleri get ile servera bilgi gönderirken ise post metodu kullanılıyor.
        public ActionResult Create() //İlk sayfa açıldığında boş view gelmesi için GET kısmı çalışır.
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] //Kaydete tıklandığında 
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Category category) //Formdan girilen bilgiler parametrelere aktarılır ve category içerisine paketlenir. Bind güvenlik açısından kullanılır. İstenilen verilerin geldiğinden emin olmak için.
        {
            if (ModelState.IsValid) //Model sınıftaki kuralların hepsi yerine getirilmişse burası çalışır. Entity için yazılan kurallar doğru mu? 20karakterden kısa olması vs.
            {
                db.Categories.Add(category); //Veritabanına ekler
                db.SaveChanges();
                return RedirectToAction("Index"); //index sayfasına yönlendirir.
            }

            return View(category); //Eğer hata olmuşsa veriler kaybolmadan textboxların içinde kalır.
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id) //Güncelleye basıldığında çalışacak metod.
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified; //Veritabanı güncelleme işlemi
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category); //Eğer isvalid değilse girilen formu geri döndürür.
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")] // Burada delete'in post metodu olduğu gösteriliyor.
        [ValidateAntiForgeryToken] //Get ile Post arasında bağlantı oluşturmak için. Get ile gönderilen tokenı doğruluyor. Güvenlik açısından.
        public ActionResult DeleteConfirmed(int id)//Get metodu ile aynı isimde olmayacağından DeleteConfirmed dendi ancak ^
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
