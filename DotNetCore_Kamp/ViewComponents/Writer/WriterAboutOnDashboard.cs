using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.ViewComponents.Writer
{
    public class WriterAboutOnDashboard: ViewComponent
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());

        public IViewComponentResult Invoke()
        {
            var values = wm.GetWriterById(4);
            return View(values);
        }
    }
}
