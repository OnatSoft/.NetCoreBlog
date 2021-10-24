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
    public class AboutManager: IAboutService
    {
        IAboutDal _AboutDal;

        public AboutManager(IAboutDal aboutDal)  // *** About Manager Constructor **
        {
            _AboutDal = aboutDal;
        }

        public About GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
            throw new NotImplementedException();
        }

        public List<About> GetListAll()
        {
            return _AboutDal.GetListAll();
        }

        public void TAdd(About tadd)
        {
            throw new NotImplementedException();
        }

        public void TDelete(About tdelete)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About tupdate)
        {
            throw new NotImplementedException();
        }
    }
}