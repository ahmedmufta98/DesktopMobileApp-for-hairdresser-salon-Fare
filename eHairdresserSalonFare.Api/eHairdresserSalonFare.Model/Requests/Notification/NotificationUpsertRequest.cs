using System;

namespace eHairdresserSalonFare.Model.Requests.Notification
{
    public class NotificationUpsertRequest
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime NotificationDate { get; set; }
        public int HairdresserSalonId { get; set; }
    }
}
