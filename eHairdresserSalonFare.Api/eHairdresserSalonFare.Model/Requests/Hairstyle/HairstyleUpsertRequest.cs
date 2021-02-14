namespace eHairdresserSalonFare.Model.Requests.Hairstyle
{
    public class HairstyleUpsertRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public float Price { get; set; }
    }
}

