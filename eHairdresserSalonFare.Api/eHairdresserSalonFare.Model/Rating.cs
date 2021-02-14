namespace eHairdresserSalonFare.Model
{
    public class Rating
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public int HairdresserId { get; set; }
        public int UserId { get; set; }
    }
}
