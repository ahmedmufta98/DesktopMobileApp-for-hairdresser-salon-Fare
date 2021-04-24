using System.ComponentModel.DataAnnotations;

namespace eHairdresserSalonFareBugojno.Database
{
    public class Hairstyle
    {
        [Key]
        public int Id { get; set; }
        public string HairstyleName { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public float Price { get; set; }
        public int DurationOfProduction { get; set; }
        public HairdresserHairstyle HairdresserHairstyle { get; set; }
    }
}