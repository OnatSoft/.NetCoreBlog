﻿using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.ViewComponents.Writer
{
    public class WriterNotification :ViewComponent
    {
        NotificationManager Nm = new NotificationManager(new EFNotificationRepository());

        public IViewComponentResult Invoke()  //** Yazar Panelinde Bildirimleri listelemek için kullandık //
        {
            var values = Nm.GetList();
            return View(values);
        }
    }
}
