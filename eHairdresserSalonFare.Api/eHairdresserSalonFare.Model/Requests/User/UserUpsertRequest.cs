namespace eHairdresserSalonFare.Model.Requests.User
{
    public class UserUpsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BankCardNumber { get; set; }
        public byte[] Image { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public int RoleId { get; set; }
    }
}
