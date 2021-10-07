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

        public CommentManager(ICommentDal commentDal)
        {
            _CommentDal = commentDal;
        }

        public void CommentAdd(Comment addcomment)
        {
            _CommentDal.Insert(addcomment);
        }

        public List<Comment> GetList(int id)
        {
            return _CommentDal.GetListAll(x => x.BlogID == id);
        }

    }
}
