using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Identity
{
    public class ApplicationUser : IdentityUser
    {//Extra eklememiz gereken bilgileri buraya yazıyoruz.
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}