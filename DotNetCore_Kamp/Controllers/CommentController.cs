using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EFCommentRepository());
        
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialAddComment()
        {
            /*--- Yorum ekleme kısmını ana Blog Details sayfasından ayırıp buraya Controller sınıfı tanımladık
             * Ve Yorum Ekleme kısmını yeni sayfaya aldık ---*/
            return PartialView();
        }
        public PartialViewResult PartialCommentList(int id)
        {
            var values= cm.GetList(id);
            return PartialView(values);
        }
    }
}
