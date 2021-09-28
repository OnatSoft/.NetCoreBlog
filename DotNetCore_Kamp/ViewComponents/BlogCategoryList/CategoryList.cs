using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.ViewComponents.BlogCategoryList
{
    public class CategoryList: ViewComponent  /*==== Blog detay sayfasında bulunan ve çağrılan mini kategori listesi için Class oluşturuldu ====*/
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
