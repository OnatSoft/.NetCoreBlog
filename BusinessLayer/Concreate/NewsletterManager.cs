using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{                                /****** Blog E-posta Bültenine Abone Olma ******/
    public class NewsletterManager: INewsletterService
    {
        INewsletterDal _newslettersubscribe;

        public NewsletterManager(INewsletterDal newslettersubscribe)  //*** INewsletterDal'dan oluşturulan Constructor metod ***
        {
            _newslettersubscribe = newslettersubscribe;
        }

        public Newsletter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Newsletter> GetList()
        {
            throw new NotImplementedException();
        }

        public void NewsletterDelete(Newsletter newsletterdel)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Newsletter tadd)
        {
            _newslettersubscribe.Insert(tadd);
        }

        public void TDelete(Newsletter tdelete)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Newsletter tupdate)
        {
            throw new NotImplementedException();
        }
    }
}