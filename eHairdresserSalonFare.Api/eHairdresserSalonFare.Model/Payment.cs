using System;

namespace eHairdresserSalonFare.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public float Amount { get; set; }
        public int UserId { get; set; }
    }
}
