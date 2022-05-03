using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
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
        Context C = new Context();

        public IActionResult Index() //Widgets - İstatistik View Sayfası
        {
            
            return View();
        }
    }
}
