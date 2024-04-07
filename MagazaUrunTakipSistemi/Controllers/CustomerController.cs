using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunTakipSistemi.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MagazaUrunTakipSistemi.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        RG_MAGAZASTOKYONETIMEntities db = new RG_MAGAZASTOKYONETIMEntities();
        public ActionResult Customer(int  sayfa = 1) // sayfamızın hangi sayfadan başlayacağını belirleriz
        {

            //var model = db.TBL_MUSTERI.ToList();
           var model = db.TBL_MUSTERI.ToList().ToPagedList(sayfa, 7); // burada method iki değer alır. 1.Değer : kaçıncı sayfadan başlayacağımızın değeri, 2. Değer : 1 sayfada kaç veri listeleneceği.
            //var model = db.TBL_MUSTERI.Where(x => x.status == true).ToList().ToPagedList(sayfa, 7); // bu sadece durtumu true olanları gösterir
            return View(model);
        }

        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(TBL_MUSTERI m) {

            if(!ModelState.IsValid) // dogrulama dogru şekilde yapılmamıssa burayı döndür. yapılmıssa aşağıdaki kodu döndür.
            {
                return View("NewCustomer");
            }   

            m.status = true;
            db.TBL_MUSTERI.Add(m);
            db.SaveChanges();
            return RedirectToAction("Customer");
        }

        public ActionResult DeleteCustomer(TBL_MUSTERI m)
        {

            var deletecustomer = db.TBL_MUSTERI.Find(m.id);
            deletecustomer.status = false;
            db.SaveChanges();
            return RedirectToAction("Customer");
        }

        public ActionResult ActiveCustomer (TBL_MUSTERI m)
        {
            var activecustomer = db.TBL_MUSTERI.Find(m.id);
            activecustomer.status = true;
            db.SaveChanges();
            return RedirectToAction("Customer");
        }

        public ActionResult BringCustomer(int id)
        {
            var customer = db.TBL_MUSTERI.Find(id);
            return View("BringCustomer", customer);
        }

        public ActionResult UpdateCustomer(TBL_MUSTERI m)
        {
            var updt = db.TBL_MUSTERI.Find(m.id);
            updt.musteriadi = m.musteriadi;
            updt.musterisoyadi = m.musterisoyadi;
            updt.musteribakiye = m.musteribakiye;
            updt.musterisehir = m.musterisehir;
            updt.status = m.status;
            db.SaveChanges();
            return RedirectToAction("Customer");
        }
    }
}