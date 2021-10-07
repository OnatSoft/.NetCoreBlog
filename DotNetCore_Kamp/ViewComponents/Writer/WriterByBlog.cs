using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.ViewComponents.Writer
{
    public class WriterByBlog: ViewComponent     //*** Kenar çubuğunda sadece yazara ait blogları getiriliyor. View Component Sayfası
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogListByWriter(2);  //** Blog detay sayfasında olan Yazarın son blogları bölümünde sadece Yazar ID'si 1 olan blogları getiriyor.
            return View(values);
        }
    }
}
