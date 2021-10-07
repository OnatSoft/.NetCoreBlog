using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]  //***** İletişim sayfasında ki iletişim formu gönderileceği zaman yapılacaklar
        public IActionResult Index(Contact p)
        {
            p.DateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            cm.ContactAdd(p);
            return RedirectToAction("Index", "Blog");
        }
    }
}
