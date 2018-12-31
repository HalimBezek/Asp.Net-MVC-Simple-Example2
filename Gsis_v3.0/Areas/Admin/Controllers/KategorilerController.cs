using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gsis.Models;

namespace Gsis.Areas.Admin.Controllers
{
    public class KategorilerController : BaseController
    {
        //
        // GET: /icerik/
        public ActionResult Index()
        {
            ViewBag.menu = data.KATEGORILERs.Where(f => f.UST_KATEGORI_ID == 0);
            return View();
        }


        public ActionResult listele()
        {
            ViewBag.kategoriler = data.KATEGORILERs;

            return View();
        }






        public ActionResult ekle()
        {
            ViewBag.kategoriler = data.KATEGORILERs;
            return View();
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ekle(string kategori_adi, string icerik, string meta_title, string meta_desc, string meta_key, int kategori_id,  bool ust_menu, bool durum, int sira_no, bool icerik_eklensinmi)
        {

            //try
            //{


            if (icerik_eklensinmi)
            {

                KATEGORILER yeni_kategori = new KATEGORILER();

                yeni_kategori.DURUM = durum;
                yeni_kategori.KATEGORI_ADI = kategori_adi;
                yeni_kategori.SILME_IZNI = true;
                yeni_kategori.SIRA_NO = sira_no;
                yeni_kategori.URL = "";
                yeni_kategori.UST_KATEGORI_ID = kategori_id;
                yeni_kategori.UST_MENU = ust_menu;

                data.KATEGORILERs.InsertOnSubmit(yeni_kategori);

                data.SubmitChanges();


                yeni_kategori.URL = yeni_kategori.ID + "/" + kategori_adi.ToURL();
                data.SubmitChanges();

                ICERIK yeni_icerik = new ICERIK();

                yeni_icerik.DESCRIPTION = meta_desc;
                yeni_icerik.ICERIK1 = icerik.Replace("&nbsp;", " ");
                yeni_icerik.KEYWORDS = meta_key;
                yeni_icerik.MENU_ID = yeni_kategori.ID;
                yeni_icerik.TITLE = meta_title;
                yeni_kategori.ICERIK = true;

                data.ICERIKs.InsertOnSubmit(yeni_icerik);

                data.SubmitChanges();



                mesaj[0] = "alert-info"; mesaj[1] = "Kategori Başarıyla Eklendi..";
                ViewBag.mesaj = mesaj;

            }
            else
            {

                KATEGORILER yeni_kategori = new KATEGORILER();

                yeni_kategori.DURUM = durum;
                yeni_kategori.KATEGORI_ADI = kategori_adi;
                yeni_kategori.SILME_IZNI = true;
                yeni_kategori.SIRA_NO = sira_no;
                yeni_kategori.URL = "";
                yeni_kategori.UST_KATEGORI_ID = 0;
                yeni_kategori.UST_MENU = true;
                yeni_kategori.ICERIK = false;

                data.KATEGORILERs.InsertOnSubmit(yeni_kategori);
                data.SubmitChanges();


                yeni_kategori.URL = "#";
                data.SubmitChanges();

                mesaj[0] = "alert-info"; mesaj[1] = "Kategori Başarıyla Eklendi..";
                ViewBag.mesaj = mesaj;
            }


                

            //}
            //catch
            //{
            //    mesaj[0] = "alert-error"; mesaj[1] = "Eklenirken hata oluştu !";
            //    ViewBag.mesaj = mesaj;
            //}

                ViewBag.icerik = data.ICERIKs;
                ViewBag.kategoriler = data.KATEGORILERs;
              
            return View("listele");
        }









        public ActionResult sil()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            var kategori = data.KATEGORILERs.First(f => f.ID == id);

            if (kategori.SILME_IZNI == true)
            {


                if (kategori.ICERIK.Value)
                {
                    data.KATEGORILERs.DeleteOnSubmit(kategori);
                    data.SubmitChanges();

                    var icerik = data.ICERIKs.First(F => F.MENU_ID == id);
                    data.ICERIKs.DeleteOnSubmit(icerik);

                    data.SubmitChanges();
                }
                else
                {
                    data.KATEGORILERs.DeleteOnSubmit(kategori);
                    data.SubmitChanges();

                }

               

                mesaj[0] = "alert-info"; mesaj[1] = "Kategori Durumu Güncellendi..";
                ViewBag.mesaj = mesaj;
            }
            else
            {
                mesaj[0] = "alert-danger"; mesaj[1] = "Bu Kategori Silinemez !";
                ViewBag.mesaj = mesaj;
            }

            ViewBag.icerik = data.ICERIKs;
            ViewBag.kategoriler = data.KATEGORILERs;

            return View("listele");
        }




        public ActionResult durum()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            bool durum = Convert.ToBoolean(Request.QueryString["durum"]);


            var kategori = data.KATEGORILERs.First(f => f.ID == id);
            kategori.DURUM = durum;

            data.SubmitChanges();


            ViewBag.icerik = data.ICERIKs;
            ViewBag.kategoriler = data.KATEGORILERs;

            mesaj[0] = "alert-info"; mesaj[1] = "Kategori Durumu Güncellendi..";
            ViewBag.mesaj = mesaj;



            return View("listele");
        }

 




        [ValidateInput(false)]
        [HttpPost]
        public ActionResult duzenle(string kategori_adi, string icerik, string meta_title, string meta_desc, string meta_key, int kategori_id,  bool ust_menu, bool durum, int sira_no)
        {

            int id = Convert.ToInt32(Request.QueryString["id"]);

            var kategori = data.KATEGORILERs.First(f => f.ID == id);


            if (kategori.ICERIK.Value)
            {
              
                if (kategori.SILME_IZNI == false)
                {


                    var icrk = data.ICERIKs.First(f => f.SAYFA_NO == kategori.SAYFA_NO);


                    kategori.DURUM = durum;
                    kategori.KATEGORI_ADI = kategori_adi;
                    kategori.SIRA_NO = sira_no;
                    //kategori.URL = "";
                    kategori.UST_KATEGORI_ID = kategori_id;
                    kategori.UST_MENU = ust_menu;

                    data.SubmitChanges();




                    icrk.DESCRIPTION = meta_desc;
                    icrk.ICERIK1 = icerik.Replace("&nbsp;", " ");
                    icrk.KEYWORDS = meta_key;
                    icrk.TITLE = meta_title;

                    data.SubmitChanges();


                    mesaj[0] = "alert-info"; mesaj[1] = "Kategori Başarıyla Güncellendi..";
                    ViewBag.mesaj = mesaj;


                }
                else
                {


                    var icrk = data.ICERIKs.First(f => f.MENU_ID == kategori.ID);



                    kategori.KATEGORI_ADI = kategori_adi;
                    kategori.DURUM = durum;
                    kategori.SIRA_NO = sira_no;

                    data.SubmitChanges();




                    icrk.DESCRIPTION = meta_desc;
                    icrk.ICERIK1 = icerik.Replace("&nbsp;", " ");
                    icrk.KEYWORDS = meta_key;
                    icrk.TITLE = meta_title;
                    data.SubmitChanges();



                    mesaj[0] = "alert-info"; mesaj[1] = "Kısıtlı Bölümler Güncellendi..";
                    ViewBag.mesaj = mesaj;

                }
            }
            else
            {
             
                if (kategori.SILME_IZNI == false)
                {
                    kategori.DURUM = durum;
                    kategori.KATEGORI_ADI = kategori_adi;
                    kategori.SIRA_NO = sira_no;

                    data.SubmitChanges();

                    mesaj[0] = "alert-info"; mesaj[1] = "Kategori Başarıyla Güncellendi..";
                    ViewBag.mesaj = mesaj;


                }
                else
                {
                    kategori.KATEGORI_ADI = kategori_adi;
                    kategori.DURUM = durum;
                    kategori.SIRA_NO = sira_no;

                    data.SubmitChanges();

                    mesaj[0] = "alert-info"; mesaj[1] = "Kısıtlı Bölümler Güncellendi..";
                    ViewBag.mesaj = mesaj;
                }
            }
            
            
            
            
            
            


            //}
            //catch
            //{
            //    mesaj[0] = "alert-error"; mesaj[1] = "Eklenirken hata oluştu !";
            //    ViewBag.mesaj = mesaj;
            //}

            //ViewBag.icerik = data.ICERIKs.First(f => f.MENU_ID == kategori.ID);
            //ViewBag.kategoriler = data.KATEGORILERs;
            //var kat = data.KATEGORILERs.First(f => f.ID == id);
            //ViewBag.kategori = kat;

    
            ViewBag.kategoriler = data.KATEGORILERs;

            return View("listele");
        }




        public ActionResult duzenle()
        {

            // silme izni yok - içerik var sa     özel sayfa dır



            int id = Convert.ToInt32(Request.QueryString["id"]);

            var kat = data.KATEGORILERs.First(f => f.ID == id);
            bool icerik_varmi = kat.ICERIK.Value;

            if (icerik_varmi)
            {
                if(kat.SILME_IZNI.Value == false)
                {
                    ViewBag.icerik = data.ICERIKs.First(f => f.SAYFA_NO == kat.SAYFA_NO);
                    ViewBag.kategoriler = data.KATEGORILERs;
                    ViewBag.kategori = kat;

                }else
                {
                    ViewBag.icerik = data.ICERIKs.First(f => f.MENU_ID == id);
                    ViewBag.kategoriler = data.KATEGORILERs;
                    ViewBag.kategori = kat;
                }
                   
            }
            else
            {
                ViewBag.kategoriler = data.KATEGORILERs;
                ViewBag.kategori = kat;
            }

            return View();
        }

	}
}