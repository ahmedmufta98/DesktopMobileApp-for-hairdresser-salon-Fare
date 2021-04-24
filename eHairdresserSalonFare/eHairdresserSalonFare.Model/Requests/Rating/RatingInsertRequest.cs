namespace eHairdresserSalonFare.Model.Requests.Rating
{
    public class RatingInsertRequest
    {
        public int Rate { get; set; }
        public int HairdresserId { get; set; }
        public int UserId { get; set; }
    }
}
