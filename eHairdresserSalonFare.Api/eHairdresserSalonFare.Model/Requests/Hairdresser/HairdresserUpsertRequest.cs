using System;

namespace eHairdresserSalonFare.Model.Requests.Hairdresser
{
    public class HairdresserUpsertRequest
    {
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
    }
}
