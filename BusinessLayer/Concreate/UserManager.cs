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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<AppUser> GetList()
        {
            return _userDal.GetListAll();
        }

        public void TAdd(AppUser tadd)
        {
            _userDal.Insert(tadd);
        }

        public void TDelete(AppUser tdelete)
        {
            _userDal.Delete(tdelete);
        }

        public AppUser TGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public void TUpdate(AppUser tupdate)
        {
            _userDal.Update(tupdate);
        }
    }
}
