using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.ViewComponents.Blog
{
    public class BlogLast3Post: ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = bm.GetLast3Blog();  //** Footer alanında ki "Son 3 Gönderiler" bölümü View Component sayfası
            return View(values);
        }
    }
}
