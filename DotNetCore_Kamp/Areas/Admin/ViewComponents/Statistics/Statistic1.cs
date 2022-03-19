using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic1: ViewComponent
    {

        public IViewComponentResult Invoke()  //Admin Panelinde İstatistik View Component sayfası
        {
            return View();
        }
    }
}
