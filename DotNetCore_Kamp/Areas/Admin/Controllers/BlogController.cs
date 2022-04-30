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
        public IActionResult BlogListExcelStatic()  //** Statik olarak blogların Excel dosyasını indirme View Sayfası **//
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
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BlogListReport_Static.xlsx");
                }
            }
        }  //** Statik olarak Blogları Excel dosyasına aktarma **//

        public List<BlogModel> GetBlogList()  //** Blogları statik olarak listeledik **//
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{BlogID=1, BlogName="Java ve Flutter Karşılaştırması"},
                new BlogModel{BlogID=2, BlogName="C# ile E-posta Gönderme"},
                new BlogModel{BlogID=3, BlogName="Apple ile Porshe otomobil için işbirliği yapabilir"},
                new BlogModel{BlogID=4, BlogName="Java Navigation Component Kullanımı"}
            };
            return bm;
        }


        //***************************************************************************************************************************************//


        public IActionResult BlogListExcelDynamic()  //** Dinamik olarak blogların Excel dosyasını İndirme View Sayfası **//
        {
            return View();
        }

        public IActionResult DynamicExportExcelBlogList()  //** Dinamik olarak Blog Listesini Excel Dosyasına aktarma **//
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Blog Başlığı";
                worksheet.Cell(1, 3).Value = "Yazar Adı Soyadı";
                worksheet.Cell(1, 4).Value = "Oluşturma Tarihi";
                worksheet.Cell(1, 5).Value = "Blog Resmi";
                worksheet.Cell(1, 6).Value = "Blog Küçük Resmi";

                int Blogrowcount = 2;
                foreach (var item in GetTitleBlogList())
                {
                    worksheet.Cell(Blogrowcount, 1).Value = item.BlogID;
                    worksheet.Cell(Blogrowcount, 2).Value = item.BlogName;
                    worksheet.Cell(Blogrowcount, 3).Value = item.BlogAuth;
                    worksheet.Cell(Blogrowcount, 4).Value = item.CreateDate;
                    worksheet.Cell(Blogrowcount, 5).Value = item.Blogİmage;
                    worksheet.Cell(Blogrowcount, 6).Value = item.BlogThumbnailİmage;
                    Blogrowcount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BlogListReport_Dynamic.xlsx");
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
                    CreateDate = x.CreateDate.ToString(),
                    Blogİmage = x.İmage,
                    BlogThumbnailİmage = x.ThumbnailImage,

                }).ToList();
            }
            return bm2;

        }
    }
}