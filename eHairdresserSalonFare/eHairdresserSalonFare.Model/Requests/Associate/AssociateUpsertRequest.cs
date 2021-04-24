namespace eHairdresserSalonFare.Model.Requests.Associate
{
    public class AssociateUpsertRequest
    {
        public string AssociateName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int HairdresserSalonId { get; set; }
    }
}
