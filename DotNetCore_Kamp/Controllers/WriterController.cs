using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    // [Authorize] Controller Seviyesinde Authorize
    //*** Yazar paneline veya bir sayfaya kullanıcı girişli erişiliyorsa bunu sağlayan Authorize Attribute Methodu ***//
    //*** Yazar Paneline veya bir sayfaya erişirken yetkisiz erişiliyorsa yani sisteme giriş yapmadan erişiliyorsa hata veren Atrribute Methodu ***//
    
    public class WriterController : Controller
    {
        //*** Bütün proje seviyesinde kullanıcı giriş zorunluluğu (Authorize) olduğu için Yazar Login sayfasını bu zorunluluktan muaf (devre dışı) bıraktığı için erişilebiliyor. ***//
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()  //** Yazar Paneli yan menülerin partial bölümü **//
        {
            return PartialView();
        }
    }
}
