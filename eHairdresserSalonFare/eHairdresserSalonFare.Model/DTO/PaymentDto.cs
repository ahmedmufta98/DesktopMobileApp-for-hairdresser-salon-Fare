using System;

namespace eHairdresserSalonFare.Model.DTO
{
    public class PaymentDto
    {
        public string ClientName { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Purpose { get; set; }
        public float Price { get; set; }
    }
}
