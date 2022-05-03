using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        Message2Manager Mm = new Message2Manager(new EFMessage2Repository());
        Context c = new Context();

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Inbox() //Yazar panelinde Gelen Kutusu methodu
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.EMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = Mm.GetInboxListByWriter(writerID);
            ViewBag.Writername = username;
            return View(values);
        }

        public IActionResult Sendbox() //Yazar panelinde Giden Kutusu methodu
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.EMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = Mm.GetSendboxListByWriter(writerID);
            ViewBag.Writername = username;
            return View(values);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id) //Yazar panelinde bir mesajın detay/içerik sayfası methodu
        {
            var username = User.Identity.Name;
            ViewBag.Writername = username;

            var value = Mm.TGetById(id);
            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            var username = User.Identity.Name;
            ViewBag.Writername = username;

            List<SelectListItem> receiverUser = (from x in await GetUsersAsync()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.NameSurname.ToString(),
                                                     Value = x.Id.ToString()

                                                 }).ToList();
            ViewBag.ReceiverUser = receiverUser;
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 message2) //Yazar panelinde bir gönderici, alıcıya mesaj gönderme methodu
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.EMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            message2.SenderID = writerID;
            message2.Status = true;
            message2.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            Mm.TAdd(message2);
            return RedirectToAction("Inbox");
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
