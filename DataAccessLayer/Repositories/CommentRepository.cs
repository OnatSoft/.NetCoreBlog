using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CommentRepository : IGenericDal<Comment>
    {
        public void Delete<T>(T t)
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert<T>(T t)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T t)
        {
            throw new NotImplementedException();
        }
    }
}
