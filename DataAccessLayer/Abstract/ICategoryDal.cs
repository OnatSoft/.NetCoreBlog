using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface ICategoryDal
    {
        // Category sınıfında CRUD işlemlerini yapmak için interface'ler tanımlanıyor.
        // Category ekleme/silme/güncelleme işlemlerini VOİD metoduyla tanımladık ve category işlemlerini bir ID ile kontrol edebilmek için GetById tanımlıyoruz.

        List<Category> ListAllCategory();
        void AddCategory(Category categoryname);
        void DeleteCategory(Category categorydel);
        void UpdateCategory(Category categoryup);
        Category GetById(int id);

    }
}
