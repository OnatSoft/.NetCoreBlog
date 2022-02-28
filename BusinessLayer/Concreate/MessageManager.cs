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
    public class MessageManager : IMessageService  //** Burası IMessageService'den miras alıyor/kullanıyor //
    {
        IMessageDal _MessageDal;
        public MessageManager(IMessageDal messageDal)  //** IMessageDal interface'den constructor method oluşturduk //
        {
            _MessageDal = messageDal;
        }


        public List<Message> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Message> GetInboxListByWriter(string p)  //** Yazar Panelinde yazara göre Mesajları Listelemek için kullandık //
        {
            return _MessageDal.GetListAll(x => x.Receiver == p);
        }

        public void TAdd(Message tadd)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message tdelete)
        {
            throw new NotImplementedException();
        }

        public Message TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message tupdate)
        {
            throw new NotImplementedException();
        }
    }
}
