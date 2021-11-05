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
    public class WriterManager : IWriterService
    {
        IWriterDal _WriterDal;

        public WriterManager(IWriterDal writerDal)  /*--- IWriterDal için oluşturulmuş Constructor ---*/
        {
            _WriterDal = writerDal;
        }

        public Writer TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Writer tadd)
        {
            _WriterDal.Insert(tadd);
        }

        public void TDelete(Writer tdelete)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Writer tupdate)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterById(int id)  //*** Yazar paneli Ana sayfasında yer alan "Yazar Hakkında" kısmı için yazılan komut ***//
        {
            return _WriterDal.GetListAll(x => x.WriterID == id); 
        }
    }
}