using System;

namespace eHairdresserSalonFare.Model.Requests.Payment
{
    public class PaymentUpsertRequest
    {
        public DateTime PaymentDate { get; set; }
        public float Amount { get; set; }
        public int UserId { get; set; }
        public string BankCardNumber { get; set; }
    }
}
