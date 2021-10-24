using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T tadd);
        void TDelete (T tdelete);
        void TUpdate (T tupdate);
        List<T> GetList();
        T GetById(int id);
    }
}
