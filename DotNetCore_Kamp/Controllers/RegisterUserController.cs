using DotNetCore_Kamp.Models;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller  //* Admin Paneline kayıt olma sayfasının View Controller sınıfı
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel p)
        {
            if (!p.TermofUse)
            {
                ModelState.AddModelError("TermofUse", "Kaydınızı tamamlamak için Kullanıcı Sözleşmesini kabul etmelisiniz.");
                return View(p);
            }

            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    NameSurname = p.NameSurname,
                    Email = p.Email,
                    UserName = p.Username
                };
                
                var result = await _userManager.CreateAsync(user, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("AdminIndex", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(p);
        }
    }
}
