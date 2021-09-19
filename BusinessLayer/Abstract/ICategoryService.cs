using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        void AddCategory(Category addcategory);  // Kategori ekleme metodu
        void DeleteCategory(Category delcategory);  // Kategori silme metodu
        void UpdateCategory(Category upcategory);  // Kategori güncelleme metodu
        List<Category> GetList();  // Kategorileri listeleme
        Category GetById(int id);  // Kategorileri Id'ye göre getirme, arama vs..
    }

    // Business Katmanında Abstract klasörü içinde ki İnterface'ler "Service" olarak adlandırılıyor.
    // Business Katmanında Concreate klasörü içinde ki Class'lar "Manager" olarak adlandırılıyor.
}
