using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        List<Blog> GetBlogListWithCategory();  // Blog listesinde blogların kategorilerini isimleriyle birlikte getirmesi için İnclude Metodunu ve IBlogDal interface'ine tanımladık.
    }
}
