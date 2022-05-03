using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace DotNetCore_Kamp.Areas.Admin.Controllers
{
    [Area("Admin")]  //** Burası Admin Paneli içinde Areas klasöründe Category Controller Sayfası **//
    [Authorize(Roles ="Admin")]  //** Authorize attribute, burada ki bütün sayfaların erişimine sadece Admin rolüne izin veriyor. **//
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
                return RedirectToAction("Index");
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

        [HttpGet]
        public IActionResult CategoryEdit(int id)
        {
            var categoryValue = Cm.TGetById(id);
            return View(categoryValue);
        }

        [HttpPost]
        public IActionResult CategoryEdit(Category c)  //* Admin Panelinde kategori'yi düzenleme / güncelleme işlemi
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(c);

            if (result.IsValid)
            {
                var x = Cm.TGetById(c.CategoryID);
                x.Name = c.Name;
                x.Description = c.Description;
                Cm.TUpdate(c);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(c);
        }

        public IActionResult CategoryDelete(int id)  //* Admin Panelinde kategori'yi silme / siteden kaldırma işlemi
        {
            var value = Cm.TGetById(id);
            Cm.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryUpdateStatus(int id)  //* Admin Panelinde Kategori'nin durumunu güncelleme işlemi
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
