using System;
using System.ComponentModel.DataAnnotations;

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
