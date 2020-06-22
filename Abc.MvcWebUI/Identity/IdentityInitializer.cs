using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Abc.MvcWebUI.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Abc.MvcWebUI.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext> //Database yok ise oluştur.
    {
        protected override void Seed(IdentityDataContext context)
        {
            //Roller

            if (!context.Roles.Any(i => i.Name == "admin")) //admin rolü yok ise
            { //admin rolü oluşturalım
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "Admin Rolü" };

                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user")) //user rolü yok ise
            { //user rolü oluşturalım
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "User Rolü" };

                manager.Create(role);
            }

            //Kullanıcılar

            if (!context.Roles.Any(i => i.Name == "emrepolat")) //user rolü yok ise
            { //user rolü oluşturalım
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Emre", SurName = "Polat", UserName = "emrepolat", Email = "emrepx2@gmail.com" };

                manager.Create(user, "123456"); //şifreyi burada oluşturuyoruz.
                manager.AddToRole(user.Id, "admin"); //hem admin hem user rolünü verdik.
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Roles.Any(i => i.Name == "omamakasem")) //user rolü yok ise
            { //user rolü oluşturalım
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Omama", SurName = "Kasem", UserName = "omamakasem", Email = "omamakasem@gmail.com" };

                manager.Create(user, "123456"); //şifreyi burada oluşturuyoruz.
                manager.AddToRole(user.Id, "user"); //sadece user rolü verdik
            }

            base.Seed(context);
        }
    }
}