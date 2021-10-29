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

namespace DotNetCore_Kamp.Controllers
{
    public class BlogController : Controller
    {
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
            //ViewBag.i = id;
            //var List = bm.GetBlogById(id);
            return View(bm.TGetById(id));
        }

        public IActionResult BlogListByWriter()
        {
            var values = bm.GetListWithCategoryByWriterBm(1);  /** Yazar Panelinde Bloglarım sayfasında kategori isimlerini yazara göre getirme **/
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
            var blogValue = bm.TGetById(id);  //** Yazar panelinde dışardan gelen id'ye göre önce güncellenecek bloğun bulunması sonra güncelleme işlemi **//
            ViewBag.cv = GetCategoryList();
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog b)
        {
            var x = bm.TGetById(b.BlogID);
            x.Title = b.Title;
            x.CategoryID = b.CategoryID;
            x.İmage = b.İmage;
            x.Content = b.Content;
            b.Status = true;
            b.CreateDate = x.CreateDate;
            b.Auth = "Onat Somer";
            b.WriterID = 1;
            bm.TUpdate(b);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            //** Blog Ekleme işleminden önce "CategoryList" metodunu çağırıyor **//
            ViewBag.cv = GetCategoryList();
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            //** Yazar tarafından yeni blog ekleme işlemi **//

            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.Status = true;
                p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.Auth = "Onat Somer";
                p.WriterID = 1;
                bm.TAdd(p);

                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.cv = GetCategoryList();
            }

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