using eHairdresserSalonFare.MobileUI.APIServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly UserAPIService _apiService = new UserAPIService("users");

        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _firstName = string.Empty;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        string _lastName = string.Empty;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        string _phone = string.Empty;
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }


        public async Task Init()
        {
            Model.User user = await _apiService.GetById<Model.User>(BaseAPIService.Id);

            if (user != null)
            {
                Username = user.Username;
                FirstName = user.FirstName;
                LastName = user.LastName;
                Email = user.Email;
                Phone = user.Phone;
            }
        }

        public ICommand UpdateCommand { get; set; }

        

    }
}
