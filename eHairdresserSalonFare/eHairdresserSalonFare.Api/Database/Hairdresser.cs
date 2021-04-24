using System;
using System.ComponentModel.DataAnnotations;

namespace eHairdresserSalonFareBugojno.Database
{
    public class Hairdresser
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PersonalIdentificationNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public byte[] Image { get; set; }
        public int HairdresserSalonId { get; set; }
        public HairdresserSalon HairdresserSalon { get; set; }
        public bool Available { get; set; }
        public Booking Booking { get; set; }
    }
}
