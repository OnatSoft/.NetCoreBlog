using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace DotNetCore_Kamp.Areas.Admin.Controllers
{
    [Area("Admin")]  //** Burası Admin Paneli içinde Areas klasöründe Category Controller Sayfası **//

    public class CategoryController : Controller
    {
        CategoryManager Cm = new CategoryManager(new EFCategoryRepository());

        public IActionResult Index(int page = 1)  //* Admin Panelinde Kategorileri Listeleme ve Sayfalama İşlemi
        {
            var values = Cm.GetList().ToPagedList(page, 4);
            return View(values);
        }
    }
}
