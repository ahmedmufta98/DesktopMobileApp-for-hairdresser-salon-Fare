using eHairdresserSalonFareBugojno.Database;
using System;
using System.ComponentModel.DataAnnotations;

namespace eHairdresserSalonFare.Api.Database
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public float Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string BankCardNumber { get; set; }
    }
}
