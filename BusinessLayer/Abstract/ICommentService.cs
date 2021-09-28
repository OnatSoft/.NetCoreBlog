using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void CommentAdd(Comment addcomment);
        //void CommentDel(Comment delcomment);
        //void CommentUp(Comment upcomment);
        List<Comment> GetList(int id);
        //Comment GetById(int id);
    }
}
