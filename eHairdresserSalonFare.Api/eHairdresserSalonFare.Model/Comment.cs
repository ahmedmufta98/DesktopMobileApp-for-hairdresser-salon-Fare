﻿using System;

namespace eHairdresserSalonFare.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
