using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Newsletter
    {
        [Key]
        public int Mailid { get; set; }
        public string Email { get; set; }
        public string Captcha { get; set; }
        public bool MailStatus { get; set; }

    }
}
