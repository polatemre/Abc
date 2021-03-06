using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Abc.MvcWebUI.Entity;
using Abc.MvcWebUI.Identity;

namespace Abc.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Uygulama çalıştırıldığı anda bu initializerler devreye girecek.
            Database.SetInitializer(new DataInitializer()); // yaptığımız initializerı devreye girmesini sağlıyoruz.
            Database.SetInitializer(new IdentityInitializer()); // yaptığımız initializerı devreye girmesini sağlıyoruz.

        }
    }
}
