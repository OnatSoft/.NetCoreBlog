using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPIDemo.DataAccessLayer
{
    public class Employee  //* Statik olarak API'ler ile işlem yapılan örnek çalışan tablosu
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
