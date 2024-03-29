﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using (var c = new Context())  // Concreate klasöründen Context'te ki veritabanı bağlantısını kullan.
            {
                return c.Blogs.Include(x => x.Category).ToList();  // Context'te Blogs tanımından Kategori tablosundan ait isimleri getir.
            }
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).Where(x => x.WriterID == id).ToList();  // Yazar Panelinde bloglarım sayfasında ki kategorileri yazara göre getir.
            }
        }

        public Blog GetListCategoryName(int blogId)  // Blog Detay sayfasında kategorinin ismini yazdırma
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).FirstOrDefault(b => b.BlogID == blogId);
            }
        }
    }
}
