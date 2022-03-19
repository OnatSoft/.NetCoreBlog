using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using DataAccessLayer.Concreate;

namespace DotNetCore_Kamp.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogManager bm = new BlogManager(new EFBlogRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());

        public IActionResult Index()
        {
            /*--- Blog Controller'da Blog Manager adlı nesne oluşturup yeni EFBlog Repository tanımladık.
             * Blog Manager'da Constructure ve CRUD işlemlerini tanımladıktan sonra burada blogları listeledik. ---*/
            var values = bm.GetBlogListwithCategory();
            return View(values);
        }

        public IActionResult BlogDetails(int id)
        {
            /**--- Blog Detayları sayfasına Bloğu Id'ye göre getirme metodu ve tıklanan bloğa göre yorum getirme ---**/
            ViewBag.i = id;
            var List = bm.GetBlogById(id);
            return View(bm.TGetById(id));
        }

        public IActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.EMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            var values = bm.GetListWithCategoryByWriterBm(writerID);  /** Yazar Panelinde Bloglarım sayfasında kategori isimlerini yazara göre getirme **/
            return View(values);
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogValue = bm.TGetById(id);   //** Yazar panelinde dışardan gelen id'ye göre blog silme işlemi **//
            bm.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter");
        }


        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogValue = bm.TGetById(id);  //** Yazar panelinde dışardan gelen id'ye göre önce güncellenecek bloğun bulunması **//
            ViewBag.cv = GetCategoryList();
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog b)  //Yazar tarafından blog güncelleme işlemi
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.EMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(b);

            if (result.IsValid)
            {
                //int id = Convert.ToInt32(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name).Value); ** Blog güncellemek için yazarın id'sini alma **//
                b.WriterID = writerID;
                var x = bm.TGetById(b.BlogID);
                b.CreateDate = x.CreateDate;
                b.Status = true;
                b.Auth = x.Auth;

                bm.TUpdate(b);
                return RedirectToAction("BlogListByWriter");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            ViewBag.cv = GetCategoryList();
            return View();
        }


        [HttpGet]
        public IActionResult BlogAdd()
        {
            //** Blog Ekleme işleminden önce "CategoryList" metodunu çağırıyor **//
            ViewBag.cv = GetCategoryList();
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)  //** Yazar tarafından yeni blog ekleme işlemi **//
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.EMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var writerName = c.Writers.Where(x => x.Name == usermail).Select(y => y.Name).FirstOrDefault();

            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.WriterID = writerID;
                p.Auth = writerName;
                p.Status = true;
                p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());

                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            ViewBag.cv = GetCategoryList();
            return View();
        }


        public List<SelectListItem> GetCategoryList()
        {
            //** Blog ekleme sayfasında Kategorileri dropdown şeklinde yazdırma **//

            List<SelectListItem> categories = (from x in cm.GetList()  //** Blog Ekleme sayfasında Kategorileri dropdown list'ten seçimi **//
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,  //* Dropdown List'te "Text" özelliği, kullanıcıya görünen seçim yapabildiği değer yazılır *//
                                                   Value = x.CategoryID.ToString()  //* Dropdown List'te Value özelliği, arkaplan da görünen kullanıcıya görünmeyen değerin ID'si numarası yazılır *//
                                               }).ToList();
            return categories;
        }
    }
}