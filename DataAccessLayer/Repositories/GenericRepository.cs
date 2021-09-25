using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public List<T> GetListAll()
        {
            return C.Set<T>().ToList();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            return C.Set<T>().Where(filter).ToList();  // IGenericDal interface'ne tanımladığımız metodu burada implement edip direkt listelemek yerine "filter" şartına göre listeleme yaptık.
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
