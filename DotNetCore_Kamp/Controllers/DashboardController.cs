using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DotNetCore_Kamp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()  //** Dashboard Ana Sayfa İstatistikler
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.EMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.Writername = username; //Giriş yapan kişinin kullanıcı adı "Writer Navbar Partial" sayfasına taşınıyor.

            ViewBag.chart1 = c.Blogs.Count().ToString();  //** Yazar Dashboard sayfasında Toplam Blog sayısını SOLİD'İ ezmeden istatistiği getirme işlemi **//
            ViewBag.chart2 = c.Blogs.Where(x => x.WriterID == writerid).Count();  //** Yazar Dashboard sayfasında Yazara Ait Blogların istatistiğini getirme işlemi **//
            ViewBag.chart3 = c.Blogs.Where(x => x.CreateDate.Day < 7).Count(); //** Dashboard sayfasında yazara ait Son 7 Günde Yazılan Blogları getirme işlemi **//
            ViewBag.chart4 = c.Comments.Count().ToString();  //** Toplam Yazılan Yorumları getirme işlemi **//
            ViewBag.chart5 = c.Categories.Count().ToString();  //** Dashboard sayfasında Toplam Kategori sayısını getirmek için istatistik işlemi

            string API = "1411104e40c30f306e538aae59157b90";
            string connection2 = "https://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&units=metric&appid=" + API;
            XDocument Document = XDocument.Load(connection2);
            ViewBag.city2 = Document.Descendants("city").ElementAt(0).Attribute("name").Value;
            ViewBag.weather2 = Document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            string connection3 = "https://api.openweathermap.org/data/2.5/weather?q=izmir&mode=xml&units=metric&appid=" + API;
            XDocument Document3 = XDocument.Load(connection3);
            ViewBag.city3 = Document3.Descendants("city").ElementAt(0).Attribute("name").Value;
            ViewBag.weather3 = Document3.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}



//*** Örnek kodlar ***//
//Context c = new Context();
//ViewBag.totalBlog = c.Blogs.Count().ToString();  //** Panelim sayfasında yer alan Toplam Blog istatistiğini getirme işlemi **//
//ViewBag.yourBlog = c.Blogs.Where(x => x.WriterID == 1).Count();  //** Panelim sayfasında yer alan Blog Sayınız istatistiğini getirme işlemi **//
//ViewBag.latestBlog = c.Blogs.Where(x => x.BlogID < 7).Count();