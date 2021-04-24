using System.ComponentModel.DataAnnotations;

namespace eHairdresserSalonFareBugojno.Database
{
    public class Sponsor
    {
        [Key]
        public int Id { get; set; }
        public string SponsorName { get; set; }
        public string About { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Logo { get; set; }
        public int HairdresserSalonId { get; set; }
        public HairdresserSalon HairdresserSalon { get; set; }
    }
}
