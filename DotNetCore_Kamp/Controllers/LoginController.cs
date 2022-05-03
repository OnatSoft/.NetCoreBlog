using DataAccessLayer.Concreate;
using DotNetCore_Kamp.Models;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    //*** Bütün proje seviyesinde kullanıcı giriş zorunluluğu (Authorize) olduğu için Yazar Login sayfasını bu zorunluluktan muaf (devre dışı) bıraktığı için erişilebiliyor. ***//
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Writer p) //Claim ve Claim Principal ile Yazar Login Sayfası
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x => x.EMail == p.EMail && x.Password == p.Password);

            if (datavalue != null)
            {
                var claims = new List<Claim>  //** Eğer datavalue parametresi null (boş) değilse kullanıcının E-posta ve Şifresini alarak giriş yapıyor. **//
                            {
                                new Claim(ClaimTypes.Name, p.EMail),
                                new Claim(ClaimTypes.Email, datavalue.WriterID.ToString())
                            };

                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principle = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principle);    //* Girilen veriyi şifreli formatta çerezlere ekliyor *//

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }
        }

        public IActionResult AdminIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminIndex(UserSignInViewModel p) //Identity ile Admin Paneli Login Sayfası
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, true, true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("AdminIndex", "Login");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut() //Sistemden çıkış işlemi - Login olan kullanıcının oturumunu kaldırma
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("AdminIndex", "Login");
        }

        public IActionResult AccessDenied() //Kullanıcı Yetkisiz Erişim 403 Sayfası
        {
            return View();
        }
    }
}