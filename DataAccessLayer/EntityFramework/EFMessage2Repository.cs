using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetListWithMessageByWriter(int id)  //* Başka Yazar tarafından gönderilen mesaja Adını yazdırarak listeleme
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(x => x.SenderWriter).Where(x => x.ReceiverID == id).ToList();
            }
        }
    }
}
