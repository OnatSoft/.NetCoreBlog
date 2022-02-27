using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(Writer p)
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x => x.EMail == p.EMail && x.Password == p.Password);

            if(datavalue!= null)
            {
                var claims = new List<Claim>  //** Eğer datavalue parametresi null (boş) değilse kullanıcının E-posta ve Şifresini alarak giriş yapıyor. **//
                {
                    new Claim(ClaimTypes.Email, p.EMail),
                    new Claim(ClaimTypes.Name, datavalue.WriterID.ToString())
                };

                var useridentity = new ClaimsIdentity(claims, "d");
                ClaimsPrincipal principle = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principle);    //* Girilen veriyi şifreli formatta çerezlere ekliyor *//

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }
        }
    }
}

//Context c = new Context();
//var datavalue = c.Writers.FirstOrDefault(x => x.EMail == p.EMail && x.Password == p.Password);

//if (datavalue != null)
//{
//    HttpContext.Session.SetString("Name", p.EMail);
//    return RedirectToAction("Index", "Writer");
//}
//else
//{
//    return View();
//}