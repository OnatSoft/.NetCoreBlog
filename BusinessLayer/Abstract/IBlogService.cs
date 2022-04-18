using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService: IGenericService<Blog>
    {
        //void AddBlog(Blog addblog);  //Blog Ekleme Metodu
        //void DeleteBlog(Blog delblog);  //Blog Silme Metodu
        //void UpdateBlog(Blog upblog);  //Blog Güncelleme Metodu
        //List<Blog> GetListAll();  //Blogları Listeleme
        //Blog GetById(int id);  //Blogları ID'ye Göre Arama / Çağırma

        List<Blog> GetBlogListwithCategory();  // EFBlog Repository'de tanımladığımız İnclude metodunu Kategoriyle birlikte Blog'ları getirme methodu
        List<Blog> GetBlogListByWriter(int id);  // Blog listesini yazara göre getirme methodu oluşturduk. Blog detay sayfasında bulunan yazarın son gönderileri bölümü için
        Blog GetListCategoryName(int blogId);
    }
}
