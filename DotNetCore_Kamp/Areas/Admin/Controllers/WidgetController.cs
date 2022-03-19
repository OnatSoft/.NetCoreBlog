using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WidgetController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context C = new Context();

        public IActionResult Index() //Widgets - İstatistik View Sayfası
        {
            ViewBag.chart1 = bm.GetList().Count();
            ViewBag.chart2 = C.Contacts.Count();
            ViewBag.chart3 = C.Writers.Count();
            ViewBag.chart4 = C.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.Title).Take(1).FirstOrDefault();
            ViewBag.chart5 = C.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.Title).Take(5).FirstOrDefault();
            return View();
        }
    }
}
