using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public IFormFile İmage { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string Captcha { get; set; }
        public bool Status { get; set; }
    }
}
