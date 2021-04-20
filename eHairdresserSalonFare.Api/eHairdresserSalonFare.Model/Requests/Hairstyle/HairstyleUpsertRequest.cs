namespace eHairdresserSalonFare.Model.Requests.Hairstyle
{
    public class HairstyleUpsertRequest
    {
        public string HairstyleName { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public float Price { get; set; }
        public int DurationOfProduction { get; set; }
    }
}

