using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class CategoryManager : ICategoryService
    {
        EFCategoryRepository efCategoryRepo;

        public CategoryManager(EFCategoryRepository eFCategoryRepository)  // Category Manager Constracter Metodu ile EFCategory Repository tanımlıyoruz
        {
            efCategoryRepo = new EFCategoryRepository();
        }

        public void AddCategory(Category addcategory)
        {
            efCategoryRepo.Insert(addcategory);  // Entity Framework Category Repository CRUD ekleme işlemi
        }

        public void DeleteCategory(Category delcategory)
        {
            efCategoryRepo.Delete(delcategory);  // Entity Framework Category Repository CRUD silme işlemi
        }

        public Category GetById(int id)
        {
            return efCategoryRepo.GetById(id);  // Entity Framework Category Repository Id'ye göre arama işlemi
        }

        public List<Category> GetList()
        {
            return efCategoryRepo.GetListAll();  // Entity Framework Category Repository listeleme işlemi
        }

        public void UpdateCategory(Category upcategory)
        {
            efCategoryRepo.Update(upcategory);  // Entity Framework Category Repository güncelleme işlemi
        }
    }
}
