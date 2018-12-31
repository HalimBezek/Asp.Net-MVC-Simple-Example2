using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gsis.Models;
using System.Drawing;

namespace Gsis.Areas.Admin.Controllers
{
    [Gsis.Areas.Admin.GirisKontrol]
    public class BaseController : Controller
    {
    
        public string[] mesaj = new string[2];

        public DataClasses1DataContext data = new DataClasses1DataContext();
        public BaseController()
        { 
            @ViewBag.Title = "Admin Paneli - Gsis v1.0";
        }
	}
}








public class Resim
{
    int mGenislik;
    public int Genislik
    {
        get { return mGenislik; }
        set { mGenislik = value; }
    }

     
    public Bitmap ResimBoyutlandir(Bitmap resim, int boyut)
    {
        Bitmap sresim = resim;

        using (Bitmap OrjinalResim = resim)
        {
            double yukseklik = OrjinalResim.Height;
            double genislik = OrjinalResim.Width;
            double oran = 0;

            //if (genislik >= boyut)
            //{
                oran = genislik / yukseklik;
                genislik = boyut;
                yukseklik = genislik / oran;

                Size ydeger = new Size(Convert.ToInt32(genislik), Convert.ToInt32(yukseklik));

                Bitmap yresim = new Bitmap(OrjinalResim, ydeger);

                sresim = yresim;
            //}
           
        }

        return sresim;
    }


    public void ResimYukle(HttpPostedFileBase Dosya, string yol)
    {

        Bitmap resim = new Bitmap(Dosya.InputStream);
        
         
        //  dosyanın türüne göre de kayıt işlemini yaptırıyoruz.
        if (Dosya.ContentType == "image/jpeg" || Dosya.ContentType == "image/pjpeg")
        {
            resim.Save(yol, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        else if (Dosya.ContentType == "image/gif")
        {
            resim.Save(yol, System.Drawing.Imaging.ImageFormat.Gif);
        }
        else if (Dosya.ContentType == "image/png" || Dosya.ContentType == "image/x-png")
        {
            resim.Save(yol, System.Drawing.Imaging.ImageFormat.Png);
        }
        resim.Dispose();

    }



    public void ResimResize(HttpPostedFileBase Dosya, string yol, string watermark)
    {

       
        Bitmap resim = new Bitmap(Dosya.InputStream);
        resim = ResimBoyutlandir(resim, Genislik);

        if (string.IsNullOrEmpty(watermark))
        { 
                // watermark nul sa işlemi es geç
        }
        else
        {
            if (!string.IsNullOrEmpty(watermark) && resim.Width > 300)
            {
                Graphics graf = Graphics.FromImage(resim);

                SolidBrush firca = new SolidBrush(Color.FromArgb(70, 255, 255, 255));
                double kosegen = Math.Sqrt(resim.Width * resim.Width + resim.Height * resim.Height);
                Rectangle kutu = new Rectangle();

                //kutu.X = (int)(-90);  // alçaldıkça sola kayar
                //float yazi = (float)(kosegen / watermark.Length * 0.8);
                //kutu.Y = (int)(440); // yükseldikçe alçalır

                kutu.X = (int)(kosegen / 7);
                float yazi = (float)(kosegen / watermark.Length * 0.9);
                kutu.Y = -(int)(yazi / 1.6);


                Font fnt = new Font("arial", yazi, FontStyle.Bold);
                float egim = (float)(Math.Atan2(resim.Height, resim.Width) * 180 / System.Math.PI);
                graf.RotateTransform(egim);
                StringFormat sf = new StringFormat();
                graf.DrawString(watermark, fnt, firca, kutu, sf);
            }

        }
       

        //  dosyanın türüne göre de kayıt işlemini yaptırıyoruz.
        if (Dosya.ContentType == "image/jpeg" || Dosya.ContentType == "image/pjpeg")
        {
            resim.Save(yol, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        else if (Dosya.ContentType == "image/gif")
        {
            resim.Save(yol, System.Drawing.Imaging.ImageFormat.Gif);
        }
        else if (Dosya.ContentType == "image/png" || Dosya.ContentType == "image/x-png")
        { 
            resim.Save(yol, System.Drawing.Imaging.ImageFormat.Png); 
        }
        resim.Dispose();

    }




 
}
