using BusinessLayer.Abstract;
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
        GenericRepository<Category> CR = new GenericRepository<Category>();
        public void AddCategory(Category addcategory)
        {
            if (addcategory.Name != "" && addcategory.Description != "" && addcategory.Status == true)
            {
                CR.Insert(addcategory);
            }
           
        }

        public void DeleteCategory(Category delcategory)
        {
            CR.Delete(delcategory);
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetList()
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category upcategory)
        {
            throw new NotImplementedException();
        }
    }
}
