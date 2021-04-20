namespace eHairdresserSalonFare.Model.Requests.HairdresserSalon
{
    public class HairdresserSalonUpdateRequest
    {
        public string Salon { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Logo { get; set; }
    }
}
