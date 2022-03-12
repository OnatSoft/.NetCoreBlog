using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using DotNetCore_Kamp.Models;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    // [Authorize] Controller Seviyesinde Authorize
    //*** Yazar paneline veya bir sayfaya kullanıcı girişli erişiliyorsa bunu sağlayan Authorize Attribute Methodu ***//
    //*** Yazar Paneline veya bir sayfaya erişirken yetkisiz erişiliyorsa yani sisteme giriş yapmadan erişiliyorsa hata veren Atrribute Methodu ***//
    
    public class WriterController : Controller
    {
        //*** Bütün proje seviyesinde kullanıcı giriş zorunluluğu (Authorize) olduğu için Yazar Login sayfasını bu zorunluluktan muaf (devre dışı) bıraktığı için erişilebiliyor. ***//
        WriterManager Wm = new WriterManager(new EFWriterRepository());
        Context c = new Context();

        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.userLogin = usermail;
            var writerName = c.Writers.Where(x => x.EMail == usermail).Select(y => y.Name).FirstOrDefault();

            ViewBag.v2 = writerName;
            return View();
        }


        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            
            var writervalues = Wm.TGetById(4);
            return View(writervalues);
        }


        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)  //** Yazar profilini HTTP Post olduğunda güncelleme işlemi //
        {
            WriterValidator validations = new WriterValidator();
            ValidationResult results = validations.Validate(p);

            if (results.IsValid) //Eğer validasyonlar geçerliyse "p" parametresinden gelen profil bilgilerini güncelleyip sayfaya git.
            {
                p.WriterID = Convert.ToInt32(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name).Value);
                p.Status = true;
                Wm.TUpdate(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                
            }
            return View();
        }

        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)  //* Yazarın ilk önce profil fotoğrafını ayrı bir sayfadan ekleme işlemi //
        {
            Writer w = new Writer();
            if (p.İmage != null)  //Dosyadan herhangi resim seçip veritabanına kaydetme
            {
                var extension = Path.GetExtension(p.İmage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterİmageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.İmage.CopyTo(stream);
                w.İmage = newImageName;
            }

            w.EMail = p.EMail;
            w.Password = p.Password;
            w.PasswordRepeat = p.PasswordRepeat;
            w.Name = p.Name;
            w.About = p.About;
            w.Status = true;
            Wm.TAdd(w);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        public PartialViewResult WriterNavbarPartial()  //** Yazar Paneli yan menülerin partial bölümü **//
        {
            return PartialView();
        }

    }
}
