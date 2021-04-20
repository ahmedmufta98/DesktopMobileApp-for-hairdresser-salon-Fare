using System;

namespace eHairdresserSalonFare.Model.Requests.Comment
{
    public class CommentInsertRequest
    {
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
