using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal: IGenericDal<Message2>
    {
        List<Message2> GetInboxWithMessageByWriter(int id);  //* Yazara gelen mesajları getirme/listeleme
        List<Message2> GetSendboxWithMessageByWriter(int id);  //* Yazara göre giden mesajları getirme/listeleme
    }
}
