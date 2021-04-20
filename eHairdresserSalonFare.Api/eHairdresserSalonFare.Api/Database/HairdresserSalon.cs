using System.ComponentModel.DataAnnotations;

namespace eHairdresserSalonFareBugojno.Database
{
    public class HairdresserSalon
    {
        [Key]
        public int Id { get; set; }
        public string Salon { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Logo { get; set; }
    }
}
