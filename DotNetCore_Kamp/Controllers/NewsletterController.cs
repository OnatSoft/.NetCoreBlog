using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{                             /****** Blog bültenine abone olma Controller sayfası ******/
    public class NewsletterController : Controller
    {
        NewsletterManager subscribe =  new NewsletterManager(new EFNewsletterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {

            return PartialView();
        }
        [HttpPost]

        public IActionResult SubscribeMail(Newsletter p)
        {

            p.MailStatus = true;
            subscribe.TAdd(p);
            return RedirectToAction("Index", "Blog");
        }
    }
}
