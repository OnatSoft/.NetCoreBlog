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
    public class ContactManager: IContactService
    {
        IContactDal _contactdal;

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        public Contact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Contact tadd)
        {
            _contactdal.Insert(tadd);
        }

        public void TDelete(Contact tdelete)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contact tupdate)
        {
            throw new NotImplementedException();
        }
    }
}
