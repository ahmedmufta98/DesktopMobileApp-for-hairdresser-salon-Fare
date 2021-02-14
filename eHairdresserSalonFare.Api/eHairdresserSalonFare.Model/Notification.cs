using System;

namespace eHairdresserSalonFare.Model
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime NotificationDate { get; set; }
        public int HairdresserSalonId { get; set; }
    }
}
