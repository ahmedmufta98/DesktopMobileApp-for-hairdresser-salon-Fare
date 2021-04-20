namespace eHairdresserSalonFare.Model
{
    public class Hairstyle
    {
        public int Id { get; set; }
        public string HairstyleName { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public float Price { get; set; }
        public int DurationOfProduction { get; set; }
    }
}
