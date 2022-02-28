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
    public class NotificationManager : INotificationService //** Burası INotificationService'den miras alıyor/kullanıyor //
    {
        INotificationDal _NotificationDal;

        public NotificationManager(INotificationDal notificationDal)  //INotificationDal interface'inden constructor method oluşturduk //
        {
            _NotificationDal = notificationDal;
        }


        public List<Notification> GetList()  //* Yazar Panelinde Bildirimler penceresinde bütün değerleri listeleme //
        {
            return _NotificationDal.GetListAll();
        }

        public void TAdd(Notification tadd)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Notification tdelete)
        {
            throw new NotImplementedException();
        }

        public Notification TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notification tupdate)
        {
            throw new NotImplementedException();
        }
    }
}
