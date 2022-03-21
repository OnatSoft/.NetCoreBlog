using System.ComponentModel.DataAnnotations;

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
