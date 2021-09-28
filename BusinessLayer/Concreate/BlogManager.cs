using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class BlogManager : IBlogService
    {
        IBlogDal _BlogDal;

        public BlogManager(IBlogDal blogdal)  /*--- IBlogDal için Oluşturulan Constructure ---*/
        {
            this._BlogDal = blogdal;
        }

        public void AddBlog(Blog addblog)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlog(Blog delblog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogListwithCategory()  /*--- Bloglar listesinde Kategori adının yazması için yapılan kod satırı. Blog Listesini Kategoriyle Birlikte Getir ---*/
        {
            return _BlogDal.GetListWithCategory();
        }

        public Blog GetById(int id)  /*--- Blogları Id'ye göre çağırma / arama ---*/
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetList()  /*--- Blog listesinin tümünü getirme metodu ---*/
        {
            return _BlogDal.GetListAll();
        }

        public List<Blog> GetBlogById(int id)  /*--- Blogları / Blog'u Id'ye göre getirme metodu ---*/
        {
            return _BlogDal.GetListAll(x => x.BlogID == id);
        }

        public void UpdateBlog(Blog upblog)  /*--- Blog güncelleme metodu ---*/
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListAll()  /*--- Tümünü listeleme metodu ---*/
        {
            throw new NotImplementedException();
        }
    }
}
