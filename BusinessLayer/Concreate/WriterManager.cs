﻿using BusinessLayer.Abstract;
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
            return _WriterDal.GetById(id);
        }

        public List<Writer> GetList()
        {
            return _WriterDal.GetListAll();
        }

        public void TAdd(Writer tadd)
        {
            _WriterDal.Insert(tadd);
        }

        public void TDelete(Writer tdelete)
        {
            _WriterDal.Delete(tdelete);
        }

        public void TUpdate(Writer tupdate)
        {
            _WriterDal.Update(tupdate);
        }

        public List<Writer> GetWriterById(int id)  //*** Yazar paneli Ana sayfasında yer alan "Yazar Hakkında" kısmı için yazılan komut ***//
        {
            return _WriterDal.GetListAll(x => x.WriterID == id); 
        }
    }
}