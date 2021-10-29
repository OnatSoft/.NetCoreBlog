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

        public BlogManager(IBlogDal blogdal)  /*--- IBlogDal için Oluşturulan Constructor ---*/
        {
            this._BlogDal = blogdal;
        }

        public List<Blog> GetBlogListwithCategory()  /*--- Bloglar listesinde Kategori adını yazmak için yapılmış kod satırı, "Blog Listesini Kategoriyle Birlikte Getirme" metodu ---*/
        {
            return _BlogDal.GetListWithCategory();
        }

        public List<Blog> GetListWithCategoryByWriterBm(int id)  /*--- Yazar Panelinde Bloglarım sayfasında kategori isimlerini yazara göre getirme ---*/
        {
            return _BlogDal.GetListWithCategoryByWriter(id);
        }

        public Blog TGetById(int id)  /*--- Blogları Id'ye göre çağırma / arama ---*/
        {
            return _BlogDal.GetById(id);
        }

        public List<Blog> GetList()  /*--- Blog listesinin tümünü getirme metodu ---*/
        {
            return _BlogDal.GetListAll();
        }

        public List<Blog> GetLast3Blog()
        {
            return _BlogDal.GetListAll().OrderByDescending(x => x.BlogID).Take(3).ToList();  /*--- Footer alanında Son 3 Gönderiyi getirme metodu ---*/
        }

        public List<Blog> GetBlogById(int id)  /*--- Blogları / Blog'u Id'ye göre getirme metodu ---*/
        {
            return _BlogDal.GetListAll(x => x.BlogID == id);
        }

        public List<Blog> GetBlogListByWriter(int id)  /*--- Blog Detayda ki sağ kenarda bulunan bölüm için, "Blog Listesini Yazara Göre Getirme Metodu" ---*/
        {
            return _BlogDal.GetListAll(x => x.WriterID == id);
        }

        public void TAdd(Blog tadd)
        {
            _BlogDal.Insert(tadd);
        }

        public void TDelete(Blog tdelete)
        {
            _BlogDal.Delete(tdelete);
        }

        public void TUpdate(Blog tupdate)
        {
            _BlogDal.Update(tupdate);
        }
    }
}