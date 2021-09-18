using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
   public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public DateTime DateTime { get; set; }
        public bool Status { get; set; }

    }
}
