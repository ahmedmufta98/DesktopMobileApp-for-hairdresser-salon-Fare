using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.MobileUI.Views;
using eHairdresserSalonFare.Model.Requests.User;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly UserAPIService _apiService = new UserAPIService("users");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }

        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            if (Username == null || Username=="" || Password==null || Password=="")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Username and password are required fields!", "OK");
                return;
            }

            UserLoginRequest user = new UserLoginRequest()
            {
                Username = Username,
                Password = Password
            };
            BaseAPIService.Username = user.Username;
            BaseAPIService.Password = user.Password;

            try
            {
                Model.User loggedUser=await _apiService.Login(user);

                if (loggedUser != null)
                {
                    BaseAPIService.Id = loggedUser.Id;
                    BaseAPIService.Fullname = loggedUser.FirstName + " " + loggedUser.LastName;
                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password", "OK");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
