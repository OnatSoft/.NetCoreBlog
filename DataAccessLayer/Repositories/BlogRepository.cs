using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BlogRepository : IBlogDal
    {
        Context C = new Context();
        public void AddBlog(Blog blogname)
        {
            C.Add(blogname); // Sisteme yeni blog oluşturmak için ekleme komutu
            C.SaveChanges();
        }

        public void DeleteBlog(Blog blogdel)
        {
            C.Remove(blogdel); // Eklenen blogları sistemden silebilmek için silme komutu
            C.SaveChanges();
        }

        public Blog GetById(int id)
        {
            return C.Blogs.Find(id); // Blogların içinde bir tane aramak için veya CRUD işlemlerini yapabilmek için arama komutu
        }

        public List<Blog> ListAllBlog()
        {
            return C.Blogs.ToList(); // Eklenen blogları listelemek için
        }

        public void UpdateBlog(Blog blogup)
        {
            C.Update(blogup); // Eklenen blogları daha sonra değiştirebilmek için güncelleme komutu
            C.SaveChanges();
        }
    }
}
