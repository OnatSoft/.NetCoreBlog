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

        public WriterManager(IWriterDal writerDal)  /*--- IWriterDal için oluşturulmuş Contructer ---*/
        {
            _WriterDal = writerDal;
        }

        public void WriterAdd(Writer addwriter)  /*--- Yazar Kaydetme Metodu, IWriterService Class'ında tanımladığımız metodu burada implement ediyoruz. ---*/
        {
            _WriterDal.Insert(addwriter);
        }
    }
}
