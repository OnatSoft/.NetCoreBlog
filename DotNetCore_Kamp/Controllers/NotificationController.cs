using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager Nm = new NotificationManager(new EFNotificationRepository());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNotification()  //Yazar Panelinde Bildirimler menüsünün detaylı ayrı Bildirim Listesi sayfası
        {
            var values = Nm.GetList();
            return View(values);
        }
    }
}
