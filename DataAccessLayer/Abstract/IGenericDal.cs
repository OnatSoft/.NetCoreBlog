using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T: class
    {
        void Insert<T>(T t);
        void Delete<T>(T t);
        void Update<T>(T t);
        List<T> GetListAll();
        T GetById(int id);
        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }

    // IGenericDal interface'i aynı klasöre oluşturulan diğer interface'lere bağlı yani buraya bir metod eklendiğinde diğer interface'lere de uygulancak
}
