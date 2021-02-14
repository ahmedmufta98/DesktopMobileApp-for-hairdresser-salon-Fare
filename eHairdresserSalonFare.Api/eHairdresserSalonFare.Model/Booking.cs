using System;

namespace eHairdresserSalonFare.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public int HairdresserId { get; set; }
        public int HairstyleId { get; set; }
        public int UserId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
