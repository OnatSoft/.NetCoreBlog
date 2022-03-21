using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace DotNetCore_Kamp.Areas.Admin.Controllers
{
    [Area("Admin")]  //** Burası Admin Paneli içinde Areas klasöründe Category Controller Sayfası **//

    public class CategoryController : Controller
    {
        CategoryManager Cm = new CategoryManager(new EFCategoryRepository());

        public IActionResult Index(int page = 1)  //* Admin Panelinde Kategorileri Listeleme ve Sayfalama İşlemi
        {
            var values = Cm.GetList().ToPagedList(page, 4);
            return View(values);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)  //* Admin Panelinde Kategoriler sayfasından Yeni Kategori Ekleme işlemi
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult validations = cv.Validate(p);

            if (validations.IsValid)
            {
                p.Status = false;
                Cm.TAdd(p);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in validations.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult CategoryDelete(int id)  //* Kategori'yi silme işlemi
        {
            
            var value = Cm.TGetById(id);
            Cm.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryUpdateStatus(int id)  //* Kategori'nin durumunu güncelleme işlemi
        {
            
            var value = Cm.TGetById(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }

            Cm.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
