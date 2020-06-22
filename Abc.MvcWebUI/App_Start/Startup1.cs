using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Abc.MvcWebUI.App_Start.Startup1))]

namespace Abc.MvcWebUI.App_Start
{
    public class Startup1 //owin ile alakalı işlemler yapılacak.
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            //owin ile alakalı temel ayarları belirtmemiz gerekiyor.
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login") //Kullanıcı herhangi bir yetkisiz girişte buraya yönlendirilecek.

            });
        }
    }
}
