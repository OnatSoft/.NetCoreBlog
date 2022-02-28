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
        MessageManager Mm = new MessageManager(new EFMessageRepository());

        public IViewComponentResult Invoke()
        {
            string p;
            p = "onat.somer2017@yandex.com";
            var values = Mm.GetInboxListByWriter(p);
            return View(values);
        }
    }
}
