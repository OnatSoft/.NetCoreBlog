using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()  //** Dashboard Ana Sayfa İstatistikler
        {
            BlogManager Bm = new BlogManager(new EFBlogRepository());
            CommentManager Cm = new CommentManager(new EFCommentRepository());
            CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
            ViewBag.chart1 = Bm.GetList().Count();  //** Yazar Dashboard sayfasında Toplam Blog sayısını SOLİD'İ ezmeden istatistiği getirme işlemi **//
            ViewBag.chart2 = Bm.GetBlogListByWriter(4).Count();  //** Yazar Dashboard sayfasında Yazara Ait Blogların istatistiğini getirme işlemi **//
            ViewBag.chart3 = Bm.GetList().Where(x => x.CreateDate.Day < 7).Count();  //** Dashboard sayfasında yazara ait Son 7 Günde Yazılan Blogları getirme işlemi **//
            ViewBag.chart4 = Cm.GetList().Where(x => x.CreateDate.Day < 7).Count();  //** Yazara ait Son 7 Günde Yazılan Yorumları getirme işlemi **//
            ViewBag.chart5 = categoryManager.GetList().Count();  //** Dashboard sayfasında Toplam Kategori sayısını getirmek için istatistik işlemi
            return View();
        }
    }
}



//*** Örnek kodlar ***//
//Context c = new Context();
//ViewBag.totalBlog = c.Blogs.Count().ToString();  //** Panelim sayfasında yer alan Toplam Blog istatistiğini getirme işlemi **//
//ViewBag.yourBlog = c.Blogs.Where(x => x.WriterID == 1).Count();  //** Panelim sayfasında yer alan Blog Sayınız istatistiğini getirme işlemi **//
//ViewBag.latestBlog = c.Blogs.Where(x => x.BlogID < 7).Count();