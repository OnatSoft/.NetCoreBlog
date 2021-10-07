using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers  //********* Burası Hakkımızda Controller Sayfası **********
{
    public class AboutController : Controller
    {
        AboutManager aboutM = new AboutManager(new EFAboutRepository());

        public IActionResult Index()
        {
            var values = aboutM.GetListAll();
            return View(values);
        }

        public PartialViewResult SocialMediaAbout()
        {

            return PartialView();
        }
    }
}
