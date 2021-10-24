using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.ViewComponents.Writer
{
    public class WriterNotification :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
