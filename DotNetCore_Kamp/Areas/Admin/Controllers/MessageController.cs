using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller  //** Burası Admin paneli Mesajlar sayfası **//
    {
        Message2Manager Mm = new Message2Manager(new EFMessage2Repository());
        Context c = new Context();


        public IActionResult Inbox() //Admin paneli mesaj Gelen Kutusu
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.EMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = Mm.GetInboxListByWriter(writerID);
            ViewBag.Writername = username;
            return View(values);
        }

        public IActionResult Sendbox() //Admin paneli mesaj Giden Kutusu
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.EMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = Mm.GetSendboxListByWriter(writerID);
            ViewBag.Writername = username;
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> MessageSend() //Admin paneli yeni mesaj yazma
        {

            List<SelectListItem> receiverUsers = (from x in await GetUsersAsync()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.NameSurname.ToString(),
                                                      Value = x.Id.ToString()

                                                  }).ToList();
            ViewBag.Receiver = receiverUsers;
            return View();
        }

        [HttpPost]
        public IActionResult MessageSend(Message2 message2)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.EMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            message2.SenderID = writerID;
            message2.Status = true;
            message2.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            Mm.TAdd(message2);
            return RedirectToAction("Sendbox");
        }

        [HttpGet]
        public IActionResult MessageDetail(int id) //Admin paneli mesaj detayı
        {
            var username = User.Identity.Name;
            ViewBag.Writername = username;

            var value = Mm.TGetById(id);
            return View(value);
        }

        public async Task<List<AppUser>> GetUsersAsync()
        {
            using (var c = new Context())
            {
                return await c.Users.ToListAsync();
            }
        }
    }
}
