using MagazaUrunTakipSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaUrunTakipSistemi.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        RG_MAGAZASTOKYONETIMEntities db = new RG_MAGAZASTOKYONETIMEntities();
        public ActionResult Products()
        {
            //Sadece durumu true olan ürünleri gösterir
            //var product = db.TBL_URUN.Where(x => x.status == true).ToList();
            var product = db.TBL_URUN.ToList();
            return View(product);
        }

        [HttpGet]
        public ActionResult NewProduct()
        {

            List<SelectListItem> ktg = (from x in db.TBL_KATEGORI.ToList()

                                        select new SelectListItem

                                        {
                                            Text = x.kategoriad,
                                            Value = x.id.ToString(),
                                        }).ToList();

            ViewBag.drop = ktg;
            return View();
        }

        //Kodunuzda, NewProduct eyleminin HttpGet versiyonunda, bir seçim listesi (ktg) oluşturuyorsunuz ve bu listeyi ViewBag aracılığıyla görünüm dosyasına iletiyorsunuz. Ancak, HttpPost versiyonunda, kategori nesnesi (TBL_URUN nesnesinin bir parçası olarak) atanmadığı için hata alıyorsunuz.

        //HttpPost versiyonunda, TBL_URUN nesnesinin TBL_KATEGORI özelliğine atanmadığı için bu hatayı alıyorsunuz. Bu nedenle, HTTP Post isteği sırasında ilgili kategori nesnesini eklemeniz gerekmektedir. Bunun için, formdan seçilen kategori değerini TBL_URUN nesnesine atamalısınız.
        [HttpPost]
        public ActionResult NewProduct(TBL_URUN k)
        {
            var ktgr = db.TBL_KATEGORI.Where(x => x.id == k.TBL_KATEGORI.id).FirstOrDefault();
            k.TBL_KATEGORI = ktgr;
            db.TBL_URUN.Add(k);
            db.SaveChanges();

            return RedirectToAction("Products");
        }


        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            List<SelectListItem> ktg = (from i in db.TBL_KATEGORI.ToList()

                                          select new SelectListItem

                                          {

                                              Text = i.kategoriad,
                                              Value = i.id.ToString(),

                                          }).ToList();
            ViewBag.ktg = ktg;
            var upd = db.TBL_URUN.Find(id);
            return View("UpdateProduct", upd);
        }

        [HttpPost]
        public ActionResult UpdateProduct(TBL_URUN u) //bizim gönderdiğmiz
        {
            //u bizim gönderdiğimiz yani guncelleme sayfasından girdiğimiz veri. Urun.satısfiyat tablomuzdaki var olan veri. 
            //idsi benım gönderdiğim id ye eşit olan urun.markayı değiştir deriz vs.
            var urun = db.TBL_URUN.Find(u.id); //tablodaki veri
            urun.urunadi = u.urunadi;
            urun.urunmarka = u.urunmarka;
            urun.stok = u.stok;
            urun.alisfiyat  = u.alisfiyat;
            urun.satisfiyat  = u.satisfiyat;
            //bu kategorideki id değerim parametrenden gelen id dfdeğer.
            var ktg = db.TBL_KATEGORI.Where(x => x.id == u.TBL_KATEGORI.id).FirstOrDefault();
            urun.kategoriid = ktg.id;
            db.SaveChanges();
            return RedirectToAction("Products");
        }
  

        //URUN TABLOSUNDA SİL İŞLEMİ YAPMIYORUZ ASLINDA. BURADA TRUE FALSE YANİ URUNUN AKTIF MI PASİF Mİ OLDUGUNU KONTROL EDİYORUZ. İLİŞKİLİ TABLOLARDA SİL İŞLEMİ BU ŞEKİLDE YAPILIR.
        public ActionResult DeleteProduct(TBL_URUN u)
        {

            var findproduct = db.TBL_URUN.Find(u.id);
            findproduct.status = false;
            db.SaveChanges();

            return RedirectToAction("Products");


        }
        //ACTIVE YAPMA İŞLEMİ
        public ActionResult ActiveProduct(TBL_URUN u)
        {
            var findproduct = db.TBL_URUN.Find(u.id);
            findproduct.status = true;
            db.SaveChanges();

            return RedirectToAction("Products");
        }

    }
}


