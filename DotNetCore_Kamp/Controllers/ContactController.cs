using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    [AllowAnonymous]

    public class ContactController : Controller
    {
        ContactManager contact = new ContactManager(new EFContactRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]  //***** İletişim sayfasında ki iletişim formu gönderileceği zaman yapılacaklar
        public IActionResult Index(Contact p)
        {
            if (p.UserName != "" && p.EMail != "" && p.Subject != "" && p.Message != "")
            {
                p.DateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.Status = true;
                contact.TAdd(p);
            }
            return RedirectToAction("Index", "Contact");
        }
    }
}
