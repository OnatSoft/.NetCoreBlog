using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.ViewComponents.Writer
{
    public class WriterMessageNotification: ViewComponent
    {
        Message2Manager Mm = new Message2Manager(new EFMessage2Repository());  //** Burası Yazar Paneli içinde Mesajlar Bildirimi Popup penceresi

        public IViewComponentResult Invoke()
        {
            int id = 4;
            var values = Mm.GetInboxListByWriter(id);
            return View(values);
        }
    }
}
