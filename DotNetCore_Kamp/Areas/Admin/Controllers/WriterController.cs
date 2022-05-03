using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using DotNetCore_Kamp.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]  //** Authorize attribute, burada ki bütün sayfaların erişimine sadece Admin rolüne izin veriyor. **//

    public class WriterController : Controller  //** Ajax ile Yazarları ID'ye göre Getirme, Listeleme, Ekleme, Silme, Güncelleme işlemleri yapılıyor **//
    {
        WriterManager WM = new WriterManager(new EFWriterRepository());
        UserManager UM = new UserManager(new EFUserRepository());

        public IActionResult WriterList() //Admin Panelinde Yazarları dinamik olarak listeleme işlemi
        {
            var writerList = UM.GetList();
            return View(writerList);
        }

        public IActionResult Delete(int id) //Admin Panelinde Yazarı dinamik olarak sistemden silme işlemi
        {
            var writerDel = UM.TGetById(id);
            UM.TDelete(writerDel);
            return RedirectToAction("WriterList");
        }

        public IActionResult StatusUpdate(int Id) //Admin Panelinde Yazarın dinamik olarak durumunu güncelleme işlemi
        {
            //var writerStatus = WM.TGetById(Id);
            //if (writerStatus.Status == true)
            //{
            //    writerStatus.Status = false;
            //}
            //else
            //{
            //    writerStatus.Status = true;
            //}
            //WM.TUpdate(writerStatus);
            //return RedirectToAction("WriterList");
            return View();
        }



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

        public IActionResult GetWriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public static List<WriterModel> writers = new List<WriterModel>
        {
            new WriterModel{ ID=1, Name="Mehmet Kaplan" },
            new WriterModel{ ID=2, Name="Ali Yıldız" },
            new WriterModel{ ID=3, Name="Melisa Yıldız" },
            new WriterModel{ ID=4, Name="Deniz Yıldız" },
            new WriterModel{ ID=5, Name="Murat Demir"},
            new WriterModel{ ID=6, Name="Ebru Karagül"}
        };
    }
}