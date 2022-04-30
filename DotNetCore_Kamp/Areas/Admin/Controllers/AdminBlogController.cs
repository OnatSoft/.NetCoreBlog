using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminBlogController : Controller
    {
        BlogManager Bm = new BlogManager(new EFBlogRepository());

        public IActionResult Index()
        {
            var blogList = Bm.GetBlogListwithCategory();
            return View(blogList);
        }
    }
}
