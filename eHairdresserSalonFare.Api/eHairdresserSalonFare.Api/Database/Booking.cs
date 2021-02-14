using System;
using System.ComponentModel.DataAnnotations;

namespace eHairdresserSalonFareBugojno.Database
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int HairdresserId { get; set; }
        public Hairdresser Hairdresser { get; set; }
        public int HairstyleId { get; set; }
        public Hairstyle Hairstyle { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
