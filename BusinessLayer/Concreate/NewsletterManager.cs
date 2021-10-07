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

        public NewsletterManager(INewsletterDal newslettersubscribe)
        {
            _newslettersubscribe = newslettersubscribe;
        }

        public void NewsletterAdd(Newsletter newsletteradd)
        {
            _newslettersubscribe.Insert(newsletteradd);
        }

        public void NewsletterDelete(Newsletter newsletterdel)
        {
            throw new NotImplementedException();
        }
    }
}
