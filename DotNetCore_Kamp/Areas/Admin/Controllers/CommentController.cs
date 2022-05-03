using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class CommentController : Controller  //** Admin Panelinde Yorumlar Sayfası **//
    {
        CommentManager cm = new CommentManager(new EFCommentRepository());

        public IActionResult Index()
        {
            var commentList = cm.GetListWithBlog();
            return View(commentList);
        }

        public IActionResult CommentDelete(int id) //Admin Panelinde yorumu siteden kaldırma/silme işlemi
        {
            var valueText = cm.TGetById(id);
            cm.TDelete(valueText);
            return RedirectToAction("Index");
        }

        public IActionResult CommentStatusUpdate(int id) //Admin Panelinde yorumun durumunu güncelleme işlemi
        {
            var statusValue = cm.TGetById(id);
            if (statusValue.Status == true)
            {
                statusValue.Status = false;
            }
            else
            {
                statusValue.Status = true;
            }

            cm.TUpdate(statusValue);
            return RedirectToAction("Index");
        }
    }
}
