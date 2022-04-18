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
    public class MessageManager : IMessage2Service  //** Burası IMessageService'den miras alıyor/kullanıyor //
    {
        IMessage2Dal _MessageDal;

        public MessageManager(IMessage2Dal messageDal)
        {
            _MessageDal = messageDal;
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetSendboxListByWriter(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Message2 tadd)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message2 tdelete)
        {
            throw new NotImplementedException();
        }

        public Message2 TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message2 tupdate)
        {
            throw new NotImplementedException();
        }
    }
}
