using MagazaUrunTakipSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaUrunTakipSistemi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        RG_MAGAZASTOKYONETIMEntities db = new RG_MAGAZASTOKYONETIMEntities();
        public ActionResult Admin()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewAdmin() {

            return View();
        }
        [HttpPost]
        public ActionResult NewAdmin(TBL_ADMIN a)
        {
            db.TBL_ADMIN.Add(a);
            db.SaveChanges();
            return View();
        }



    }
}