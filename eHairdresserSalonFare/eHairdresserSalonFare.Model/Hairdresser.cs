using System;

namespace eHairdresserSalonFare.Model
{
    public class Hairdresser
    {
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
        public bool Available { get; set; }
        public string Fullname { get { return this.FirstName + " " + this.LastName; } }
    }
}
