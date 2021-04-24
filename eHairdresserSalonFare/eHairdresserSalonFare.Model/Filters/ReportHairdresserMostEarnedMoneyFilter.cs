using System;

namespace eHairdresserSalonFare.Model.Filters
{
    public class ReportHairdresserMostEarnedMoneyFilter
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? HairdresserId { get; set; }
    }
}
