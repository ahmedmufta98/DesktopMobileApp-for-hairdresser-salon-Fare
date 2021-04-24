using System.ComponentModel.DataAnnotations;

namespace eHairdresserSalonFareBugojno.Database
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
