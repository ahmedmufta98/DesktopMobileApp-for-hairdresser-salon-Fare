using System;
using System.ComponentModel.DataAnnotations;

namespace eHairdresserSalonFareBugojno.Database
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime NotificationDate { get; set; }
        public int HairdresserSalonId { get; set; }
        public HairdresserSalon HairdresserSalon { get; set; }
    }
}
