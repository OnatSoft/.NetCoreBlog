using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Notification  //** Yazar Paneli için oluşturulmuş Layout'ta yer alan Bildirim tablosu
    {
        [Key]

        public int ID { get; set; }
        public string NotificationType { get; set; }
        public string NotificationTypeSymbol { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public string NotificationColor { get; set; }
        public bool Status { get; set; }
    }
}
