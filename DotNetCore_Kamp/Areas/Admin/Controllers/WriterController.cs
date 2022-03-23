using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using DotNetCore_Kamp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller  //** Ajax ile Yazarları ID'ye göre Getirme, Listeleme, Ekleme, Silme, Güncelleme işlemleri yapılıyor **//
    {
        WriterManager WM = new WriterManager(new EFWriterRepository());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterUpdate(WriterModel w)
        {
            var Writers = writers.FirstOrDefault(x => x.ID == w.ID);
            Writers.Name = w.Name;
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        public IActionResult WriterDelete(int id)
        {
            var Writers = writers.FirstOrDefault(x => x.ID == id);
            writers.Remove(Writers);
            return Json(Writers);
        }

        [HttpPost]
        public IActionResult WriterAdd(WriterModel w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterbyID(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.ID == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        public IActionResult WriterList()
        {
            //var values = WM.GetList();
            //return View(values);

            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public static List<WriterModel> writers = new List<WriterModel>
        {
            new WriterModel{ ID=1, Name="Mehmet Kaplan" },
            new WriterModel{ ID=2, Name="Ali Yıldız" },
            new WriterModel{ ID=3, Name="Murat Yücedağ" },
            new WriterModel{ ID=4, Name="Deniz Yıldız" },
            new WriterModel{ ID=5, Name="Murat Demir"},
            new WriterModel{ ID=6, Name="Ebru Karagül"}
        };
    }
}