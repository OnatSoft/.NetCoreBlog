using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
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


        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            /*--- Yorum ekleme kısmını ana Blog Details sayfasından ayırıp buraya Controller sınıfı tanımladık
             * Ve Yorum Ekleme kısmını yeni sayfaya aldık ---*/
            return PartialView();
        }
        [HttpPost]


        public PartialViewResult PartialAddComment(Comment p)
        {
            p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogID = 3;
            p.Status = true;
            cm.CommentAdd(p);
            return PartialView();
        }


        public PartialViewResult PartialCommentList(int id)
        {
            var values= cm.GetList(id);
            return PartialView(values);
        }
    }
}
