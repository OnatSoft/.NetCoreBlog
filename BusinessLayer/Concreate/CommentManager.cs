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
            throw new NotImplementedException();
        }

        public List<Comment> GetList(int id)
        {
            return _CommentDal.GetListAll(x => x.BlogID == id);
        }

        public List<Comment> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Comment tadd)
        {
            _CommentDal.Insert(tadd);
        }

        public void TDelete(Comment tdelete)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment tupdate)
        {
            throw new NotImplementedException();
        }
    }
}
