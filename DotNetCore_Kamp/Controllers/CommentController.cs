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


        [HttpPost] // Method Post olduğunda
        public PartialViewResult PartialAddComment(Comment p)   //*** Bloglara yorum yaparken ekleneceği zaman yapılacak işlemler ***//
        {
            p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogID = 4;
            p.Status = true;
            cm.CommentAdd(p);
            return PartialView();
        }


        public PartialViewResult PartialCommentList(int id)   //*** Bloğa yapılan yorumları id'ye göre Listeleme ***//
        {
            var values= cm.GetList(id);
            return PartialView(values);
        }
    }
}
