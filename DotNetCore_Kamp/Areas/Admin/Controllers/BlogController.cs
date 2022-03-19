using ClosedXML.Excel;
using DataAccessLayer.Concreate;
using DotNetCore_Kamp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult BlogListExcelStatic()  //** Statik olarak Excel dosyasına aktarma sayfasının View Sayfası **//
        {
            return View();
        }

        public IActionResult StaticExportExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Başlığı";

                int Blogrowcount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(Blogrowcount, 1).Value = item.BlogID;
                    worksheet.Cell(Blogrowcount, 2).Value = item.BlogName;
                    Blogrowcount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CoreBlogReport.xlsx");
                }
            }
        }  //** Statik olarak Blogları Excel dosyasına aktarma/dönüştürme **//

        public List<BlogModel> GetBlogList()  //** Blogları statik olarak listeledik **//
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{BlogID=1, BlogName="C# ile Asenkron Metodlar"},
                new BlogModel{BlogID=2, BlogName="C# ile E-posta Gönderme"},
                new BlogModel{BlogID=3, BlogName="Apple ile Porshe otomobil için işbirliği yapabilir"},
                new BlogModel{BlogID=4, BlogName="Java Navigation Component Kullanımı"}
            };
            return bm;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------//
        //** Dinamik olarak Blog Listesini Excel Dosyasına aktarma
        public IActionResult DynamicExportExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Başlığı";
                worksheet.Cell(1, 3).Value = "Blog Yazarı";
                worksheet.Cell(1, 4).Value = "Blog Resmi";
                worksheet.Cell(1, 5).Value = "Blog Küçük Resmi";

                int Blogrowcount = 2;
                foreach (var item in GetTitleBlogList())
                {
                    worksheet.Cell(Blogrowcount, 1).Value = item.BlogID;
                    worksheet.Cell(Blogrowcount, 2).Value = item.BlogName;
                    worksheet.Cell(Blogrowcount, 3).Value = item.BlogAuth;
                    worksheet.Cell(Blogrowcount, 4).Value = item.Blogİmage;
                    worksheet.Cell(Blogrowcount, 5).Value = item.BlogThumbnailİmage;
                    Blogrowcount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CoreBlogList_Report.xlsx");
                }
            }
        }

        public List<BlogModel> GetTitleBlogList()
        {
            List<BlogModel> bm2 = new List<BlogModel>();
            using (var c = new Context())
            {
                bm2 = c.Blogs.Select(x => new BlogModel
                {
                    BlogID = x.BlogID,
                    BlogName = x.Title,
                    BlogAuth = x.Auth,
                    Blogİmage = x.İmage,
                    BlogThumbnailİmage = x.ThumbnailImage

                }).ToList();
            }
            return bm2;

        }

        public IActionResult BlogListExcelDynamic()
        {
            return View();
        }
    }
}