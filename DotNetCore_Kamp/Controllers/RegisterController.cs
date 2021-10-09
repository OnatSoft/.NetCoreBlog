using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        

        WriterManager wm = new WriterManager(new EFWriterRepository());

        [HttpGet]  //*** HTTPGet Attribute komutu, Kayıt sayfası yüklenince çalışır
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]  //*** HTTPPost Attribute komutu, Kayıt tamamlanınca butona basıldığı anda çalışır ve veritabanına kaydeder.
        public IActionResult Index(Writer p)
        {   //** Yazar kayıt olma işlemi

            WriterValidator Wv = new WriterValidator();
            ValidationResult results = Wv.Validate(p);
            //** Validasyon kontrolleri yazılan Writer Validator'dakileri Controller da gerçekleşmesi için tanımlandı **//
            if (results.IsValid) // Eğer dışarıdan gelen p nesnesinde ki sonuçlar geçerliyse/doğruysa kayıt işlemlerini gerçekleştir.
            {
                p.Status = true;
                p.About = "Deneme Kaydı";
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Register");  // Kayıt işlemi yapıldığında geri döndürmek üzere bloglar sayfasına git
            }
            else
            {   // Dışarıdan gelen p nesnesinde ki sonuçlar hatalıysa/geçersiz ise belirtilen hata mesajını göster.
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}
