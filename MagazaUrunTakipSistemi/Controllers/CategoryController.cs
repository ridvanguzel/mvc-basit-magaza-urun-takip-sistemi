using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunTakipSistemi.Models.Entity;
namespace MagazaUrunTakipSistemi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        //public ActionResult Index()
        //{
        //    return View();
        //}

        RG_MAGAZASTOKYONETIMEntities db = new RG_MAGAZASTOKYONETIMEntities();
        public ActionResult Category() 
        {

            var categories = db.TBL_KATEGORI.ToList();
            
            return View(categories); 
        
        
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(TBL_KATEGORI k)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            else
            {
                db.TBL_KATEGORI.Add(k);
                db.SaveChanges();
                return RedirectToAction("Category");
            }
           
        }


        public ActionResult DeleteCategory(int id)
        {
           var ktg = db.TBL_KATEGORI.Find(id);
            //db.TBL_KATEGORI.Remove(ktg);
            ktg.status = false;
            db.SaveChanges();
            return RedirectToAction("Category");
        }

        public ActionResult ActiveCategory(int id)
        {
            var ktg = db.TBL_KATEGORI.Find(id);
            ktg.status = true;
            db.SaveChanges();
            return RedirectToAction("Category");
        }

        public ActionResult UpdateCategory(int? id)
        {
            var ktg = db.TBL_KATEGORI.Find(id);

            return View("UpdateCategory", ktg);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TBL_KATEGORI uk)
        {
            var ktgup = db.TBL_KATEGORI.Find(uk.id);
            ktgup.kategoriad = uk.kategoriad;
            db.SaveChanges();
            return RedirectToAction("Category");
        }

        //soltaraftakideğertablodaki deger sağtaraftaki bizim gönderdiğimizdeger tablodaki değeri bizim göndereceğimiz değer iel değiştri eşitle deriz
        //idleri sayfalara hidden for ile saklamalıyız 
    }
}