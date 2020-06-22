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

            //Uygulama �al��t�r�ld��� anda bu initializerler devreye girecek.
            Database.SetInitializer(new DataInitializer()); // yapt���m�z initializer� devreye girmesini sa�l�yoruz.
            Database.SetInitializer(new IdentityInitializer()); // yapt���m�z initializer� devreye girmesini sa�l�yoruz.

        }
    }
}
