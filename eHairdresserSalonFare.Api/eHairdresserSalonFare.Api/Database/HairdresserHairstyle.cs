namespace eHairdresserSalonFareBugojno.Database
{
    public class HairdresserHairstyle
    {
        public int HairdresserId { get; set; }
        public Hairdresser Hairdresser { get; set; }
        public int HairstyleId { get; set; }
        public Hairstyle Hairstyle { get; set; }
    }
}
