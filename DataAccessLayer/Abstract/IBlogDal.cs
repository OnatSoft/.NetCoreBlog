using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal
    {
        // Blog sınıfında CRUD işlemlerini yapmak için interface'ler tanımlanıyor.
        // Blog ekleme/silme/güncelleme işlemlerini VOİD metoduyla tanımladık ve blog işlemlerini bir ID ile kontrol edebilmek için GetById tanımlıyoruz.

        List<Blog> ListAllBlog();
        void AddBlog(Blog blogname);
        void DeleteBlog(Blog blogdel);
        void UpdateBlog(Blog blogup);
        Blog GetById(int id);
    }
}
