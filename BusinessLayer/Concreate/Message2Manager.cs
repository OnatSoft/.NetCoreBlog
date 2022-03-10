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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _Message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)  //** IMessageDal interface'den constructor method oluşturduk //
        {
            _Message2Dal = message2Dal;
        }


        public List<Message2> GetInboxListByWriter(int id)  //** Yazar Panelinde yazara göre Mesajları Listelemek için kullandık //
        {
            return _Message2Dal.GetListWithMessageByWriter(id);
        }

        public List<Message2> GetList()
        {
            return _Message2Dal.GetListAll();
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
            return _Message2Dal.GetById(id);
        }

        public void TUpdate(Message2 tupdate)
        {
            throw new NotImplementedException();
        }
    }
}
