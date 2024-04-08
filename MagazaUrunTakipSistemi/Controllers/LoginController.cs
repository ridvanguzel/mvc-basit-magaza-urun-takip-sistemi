using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using MagazaUrunTakipSistemi.Models.Entity;

namespace MagazaUrunTakipSistemi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        RG_MAGAZASTOKYONETIMEntities db = new RG_MAGAZASTOKYONETIMEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(TBL_ADMIN a)
        {
            var information = db.TBL_ADMIN.FirstOrDefault(x => x.kullaniciadi == a.kullaniciadi && x.sifre == a.sifre);
            if(information != null)
            {
                FormsAuthentication.SetAuthCookie(information.kullaniciadi, false);
                return RedirectToAction("Customer", "Customer");
            }
            else
            {
                return View();
            }
        }
      



    }
}