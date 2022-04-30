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
    public class CommentManager : ICommentService
    {
        ICommentDal _CommentDal;

        public CommentManager(ICommentDal commentDal)  //*** ICommentDal'dan oluşturulan Constructor metod ***
        {
            _CommentDal = commentDal;
        }

        public Comment TGetById(int id)
        {
            return _CommentDal.GetById(id);
        }

        public List<Comment> GetList(int id)
        {
            return _CommentDal.GetListAll(x => x.BlogID == id);
        }

        public List<Comment> GetList()
        {
            return _CommentDal.GetListAll();
        }

        public void TAdd(Comment tadd)
        {
            tadd.BlogID = 4;
            _CommentDal.Insert(tadd);
        }

        public void TDelete(Comment tdelete)
        {
            _CommentDal.Delete(tdelete);
        }

        public void TUpdate(Comment tupdate)
        {
            _CommentDal.Update(tupdate);
        }

        public List<Comment> GetListWithBlog()
        {
            return _CommentDal.GetListCommentsWithBlog();
        }
    }
}
