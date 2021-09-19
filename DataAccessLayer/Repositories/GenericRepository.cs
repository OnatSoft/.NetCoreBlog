using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context C = new Context();

        public void Delete<T1>(T1 t)   // Tüm Repository'lere bağlı olan Generic Repository'de CRUD işlemleri yapılıyor
        {
            C.Remove(t);
            C.SaveChanges();
        }

        public T GetById(int id)
        {
            return C.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return C.Set<T>().ToList();
        }

        public void Insert<T1>(T1 t)
        {
            C.Add(t);
            C.SaveChanges();
        }

        public void Update<T1>(T1 t)
        {
            C.Update(t);
            C.SaveChanges();
        }
    }
}
