﻿namespace eHairdresserSalonFare.Model
{
    public class Associate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int HairdresserSalonId { get; set; }
    }
}
