using System;

namespace eHairdresserSalonFare.Model.Requests.Payment
{
    public class PaymentSearchRequest
    {
        public DateTime? PaymentDate { get; set; }
        public int? UserId { get; set; }
    }
}
