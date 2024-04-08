using MagazaUrunTakipSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaUrunTakipSistemi.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales

        RG_MAGAZASTOKYONETIMEntities db = new RG_MAGAZASTOKYONETIMEntities();
        public ActionResult Sales()
        {

            var model = db.TBL_SATISLAR.ToList();

            return View(model);
        }


        [HttpGet]
        public ActionResult NewSales()
        {
            //PRODUCTS

            List<SelectListItem> news = (from i in db.TBL_URUN.ToList()

                                         select new SelectListItem

                                         {

                                             Text = i.urunadi,
                                             Value = i.id.ToString()

                                         }).ToList();
            ViewBag.urundrop = news;
            //PERSONAL
            List<SelectListItem> pers = (from i in db.TBL_PERSONAL.ToList()

                                         select new SelectListItem

                                         {
                                             Text = i.personalad + " " +  i.personalsoyad,
                                             Value = i.id.ToString()

                                         }).ToList();


            ViewBag.personaldrop = pers;
            //CUSTOMER
            List<SelectListItem> musteri = (from i in db.TBL_MUSTERI.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.musteriadi + " " +  i.musterisoyadi,
                                                Value = i.id.ToString()
                                            }
                                            ).ToList();

            ViewBag.musteridrop = musteri;

            return View();
        }
        [HttpPost]
        public ActionResult NewSales(TBL_SATISLAR s)
        {

            var product = db.TBL_URUN.Where(x => x.id == s.TBL_URUN.id).FirstOrDefault();
            var personal = db.TBL_PERSONAL.Where(x => x.id == s.TBL_PERSONAL.id).FirstOrDefault();
            var customer = db.TBL_MUSTERI.Where(x=> x.id == s.TBL_MUSTERI.id).FirstOrDefault();

            s.TBL_URUN = product;
            s.TBL_PERSONAL = personal;
            s.TBL_MUSTERI = customer;
            s.tarih = DateTime.Parse(DateTime.Now.ToShortDateString()); 
            db.TBL_SATISLAR.Add(s);
            db.SaveChanges();

            return RedirectToAction("Sales");
        }
    }
}