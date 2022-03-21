using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DotNetCore_Kamp.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic1: ViewComponent
    {
        Context C = new Context();
        public IViewComponentResult Invoke()  //Admin Panelinde İstatistik birinci View Component sayfası
        {
            ViewBag.chart1 = C.Blogs.Count();
            ViewBag.chart2 = C.Contacts.Count();
            ViewBag.chart3 = C.Writers.Count();
            ViewBag.chart4 = C.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.Title).Take(1).FirstOrDefault();
            ViewBag.chart5 = C.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.Title).Take(5).FirstOrDefault();

            //** API üzerinden Admin Paneline hava durumu bilgisi çekme
            string api = "1411104e40c30f306e538aae59157b90";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.city = document.Descendants("city").ElementAt(0).Attribute("name").Value;
            ViewBag.weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}
