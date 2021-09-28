using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        public IActionResult Index()
        {
            /*--- Blog Controller'da Blog Manager adlı nesne oluşturup yeni EFBlog Repository tanımladık.
             * Blog Manager'da Constructure ve CRUD işlemlerini tanımladıktan sonra burada blogları listeledik. ---*/
            var values = bm.GetBlogListwithCategory();
            return View(values);
        }

        public IActionResult BlogDetails(int id)
        {
            /*--- Blog Detayları sayfasına Bloğu Id'ye göre getirme metodu ve tıklanan bloğa göre yorum getirme ---*/
            ViewBag.i = id;
            var List = bm.GetBlogById(id);
            return View(List);

        }
    }
}