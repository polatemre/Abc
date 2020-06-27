using Abc.MvcWebUI.Identity;
using Abc.MvcWebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abc.MvcWebUI.Entity;
using Microsoft.Owin.Security;

namespace Abc.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        [Authorize]
        public ActionResult Index()
        {
            var userName = User.Identity.Name;

            var orders = db.Orders
                .Where(i => i.Username == userName)
                .Select(i => new UserOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total
                }).OrderByDescending(i => i.OrderDate).ToList();

            return View(orders);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders
                .Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Sehir = i.Sehir,
                    Semt = i.Semt,
                    Mahalle = i.Mahalle,
                    PostaKodu = i.PostaKodu,
                    OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name.Length > 50 ? a.Product.Name.Substring(0, 47) + "..." : a.Product.Name,
                        Image = a.Product.Image,
                        Quantity = a.Quantity,
                        Price = a.Price
                    }).ToList()
                }).FirstOrDefault();

            return View(entity);
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt işlemleri

                var user = new ApplicationUser();
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //kullanıcı oluştu ve kullanıcıyı bir role atayabilirsiniz.
                    if (RoleManager.RoleExists("user")) //Eğer User rolü var ise.
                    {
                        UserManager.AddToRole(user.Id, "user"); //User rolüne kullanıcıyı ata.
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                { //Kullanıcı oluşuturulmadı ise.
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası.");
                }
            }

            return View(model);
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login işlemleri

                var user = UserManager.Find(model.UserName, model.Password); //sistemde girilen bilgilerde kullanıcı var mı?

                if (user != null) //kullanıcı null değilse sistemde vardır.
                {
                    //varolan kullanıcıyı sisteme dahil et.
                    //ApplicationCookie oluşturup sisteme bırak.

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityClaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityClaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl); //ReturnUrl var ise oraya yönlendir.
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }
            }

            return View(model);
        }

        // GET: Logout
        public ActionResult Logout()
        {
            //Oluşturulan cookie sistemden silinir.

            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}