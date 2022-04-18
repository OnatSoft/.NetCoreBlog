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
        List<Blog> GetListWithCategory();  // Blog listesinde blogların kategorilerini isimleriyle birlikte getirmesi için İnclude Metodunu ve IBlogDal interface'ine tanımladık.
        
        List<Blog> GetListWithCategoryByWriter(int id);  // Yazar Panelinde Kategorileri yazara göre getirme metodu //

        Blog GetListCategoryName(int blogId);  // Blog Detay sayfasında blogun bulunduğu kategorinin ismini yazdırma //
    }
}
