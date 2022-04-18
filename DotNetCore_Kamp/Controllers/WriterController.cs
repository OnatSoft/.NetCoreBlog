using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using DotNetCore_Kamp.Models;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        UserManager Um = new UserManager(new EFUserRepository());
        Context c = new Context();

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public WriterController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var username = User.Identity.Name;
            ViewBag.userLogin = username;
            var writerName = c.Writers.Where(x => x.EMail == username).Select(y => y.Name).FirstOrDefault();
            ViewBag.Writername = writerName;
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()  //** Yazar profilim sayfasında giriş yapan kullanıcının bilgilerini getirme //
        {
            //** 2. YÖNTEM - Yazar bilgilerini getirme
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.image = value.ImageURL;
            model.namesurname = value.NameSurname;
            model.username = value.UserName;

            var username = User.Identity.Name;
            ViewBag.Writername = username;
            return View(model);

            //** 1. YÖNTEM - Yazar bilgilerini getirme
            //var username = User.Identity.Name;
            //var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var id = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //var value = await _userManager.FindByNameAsync(User.Identity.Name);
            //var values = Um.TGetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)  //** Yazar profilini HTTP Post olduğunda güncelleme //
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.UserName = model.username;
            values.ImageURL = model.image;
            values.NameSurname = model.namesurname;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await _userManager.UpdateAsync(values);

            if (result.Succeeded && values.PasswordHash != null)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("AdminIndex", "Login");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult WriterAdd()
        {
            var username = User.Identity.Name;
            ViewBag.Writername = username;

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
