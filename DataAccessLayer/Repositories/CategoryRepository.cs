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
    public class CategoryRepository : ICategoryDal
    {
        Context C = new Context(); // **Context nesnesi global alana tanımlı olduğunda bütün interface metodlarında 1 kez kullanılabilir.

        public void AddCategory(Category categoryname)
        {
            using var c = new Context(); // **Using nesnesi interface metodlarına tek tek tanımlayarak birden çok kez kullanılabilir.

            c.Add(categoryname); // Sisteme yeni kategoriler oluşturabilmek için ekleme komutu
            c.SaveChanges();
        }

        public void DeleteCategory(Category categorydel)
        {
            using var c = new Context();

            c.Remove(categorydel); // Eklenen kategorilerin bazılarını sistemden silebilmek için silme komutu
            c.SaveChanges();
        }

        public Category GetById(int id)
        {
            return C.Categories.Find(id); // Kategorilerin içinde bir tane aramak için veya CRUD işlemlerini yapabilmek için arama komutu
        }

        public List<Category> ListAllCategory()
        {
            return C.Categories.ToList(); // Eklenen kategorileri listelemek için
        }

        public void UpdateCategory(Category categoryup)
        {
            using var c = new Context();

            c.Update(categoryup); // Eklenen kategorilerin üzerinde değişiklik yapabilmek için güncelleme komutu
            c.SaveChanges();
        }
    }
}
