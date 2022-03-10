using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager Mm = new Message2Manager(new EFMessage2Repository());

        public IActionResult Inbox()
        {
            int id = 4;
            var values = Mm.GetInboxListByWriter(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value = Mm.TGetById(id);
            return View(value);
        }
    }
}
