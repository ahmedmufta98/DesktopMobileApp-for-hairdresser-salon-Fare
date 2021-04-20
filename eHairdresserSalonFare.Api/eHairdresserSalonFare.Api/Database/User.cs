using System.ComponentModel.DataAnnotations;

namespace eHairdresserSalonFareBugojno.Database
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}