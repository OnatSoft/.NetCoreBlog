using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
   public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string İmage { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string Captcha { get; set; }
        public bool Status { get; set; }
        public List<Blog> Blogs { get; set; }

        //Yazarla Mesajların İlişkilendirilmesi
        public virtual ICollection<Message2> MessageSender { get; set; }
        public virtual ICollection<Message2> MessageReceiver { get; set; }

    }
}
