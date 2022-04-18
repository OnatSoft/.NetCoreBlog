using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessage2Service: IGenericService<Message2>
    {
        List<Message2> GetInboxListByWriter(int id);  //* Yazar Panelinde yazara gelen mesajları görüntüleme/getirme
        List<Message2> GetSendboxListByWriter(int id);  //* Yazar Panelinde yazarın gönderdiği mesajları getirme/görüntüleme
    }
}
