using System;

namespace eHairdresserSalonFare.Model.Requests.Booking
{
    public class BookingSearchRequest
    {
        public int? HairdresserId { get; set; }
        public int? HairstyleId { get; set; }
        public int? UserId { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
