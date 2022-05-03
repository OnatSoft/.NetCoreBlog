using DotNetCore_Kamp.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator, Writer")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass { categoryname = "Teknoloji", categorycount = 26 });
            list.Add(new CategoryClass { categoryname = "Yazılım", categorycount = 28 });
            list.Add(new CategoryClass { categoryname = "Seyahat", categorycount = 7 });
            list.Add(new CategoryClass { categoryname = "Bilim & Kültür", categorycount = 22 });
            list.Add(new CategoryClass { categoryname = "Sağlık", categorycount = 4 });
            list.Add(new CategoryClass { categoryname = "Haberler", categorycount = 5 });
            list.Add(new CategoryClass { categoryname = "Gündem", categorycount = 7 });
            list.Add(new CategoryClass { categoryname = "Eğlence & Oyun", categorycount = 5 });
            list.Add(new CategoryClass { categoryname = "Sanat", categorycount = 16 });
            list.Add(new CategoryClass { categoryname = "Yardımlaşma", categorycount = 10 });
            list.Add(new CategoryClass { categoryname = "Yeni Kategori 1", categorycount = 0 });
            list.Add(new CategoryClass { categoryname = "Film & Dizi", categorycount = 3 });
            list.Add(new CategoryClass { categoryname = "Yeni Kategori 2", categorycount = 0 });
            list.Add(new CategoryClass { categoryname = "Mobil", categorycount = 2 });

            return Json(new { jsonlist = list });
        }
    }
}
