using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
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
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.EMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = Mm.GetInboxListByWriter(writerID);
            return View(values);
        }
    }
}
