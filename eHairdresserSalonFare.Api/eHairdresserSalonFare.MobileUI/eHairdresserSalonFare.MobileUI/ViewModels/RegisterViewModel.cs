using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.MobileUI.Views;
using eHairdresserSalonFare.Model.Requests.User;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly UserAPIService _apiService = new UserAPIService("users");
        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await Register());
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

        string _passwordConfirm = string.Empty;
        public string PasswordConfirm
        {
            get { return _passwordConfirm; }
            set { SetProperty(ref _passwordConfirm, value); }
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

        string _phone = string.Empty;
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        DateTime _birthdate;
        public DateTime Birthdate
        {
            get { return _birthdate; }
            set { SetProperty(ref _birthdate, value); }
        }

        string _jmbg = string.Empty;
        public string JMBG
        {
            get { return _jmbg; }
            set { SetProperty(ref _jmbg, value); }
        }
        public ICommand RegisterCommand { get; set; }

        async Task Register()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Email)
                    || string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(PasswordConfirm))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "All fields are required", "Try again");
                return;
            }

            if (Password != PasswordConfirm)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Passwords don't match", "Try again");
                return;
            }

            UserUpsertRequest client = new UserUpsertRequest()
            {
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Email = Email,
                Username = Username,
                Password = Password,
                PasswordConfirm = PasswordConfirm,
                RoleId = 2
            };

            try
            {
                Model.User registredUser= await _apiService.Register(client);
                if (registredUser != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Registred succesfully.", "Now just log in.", "OK");
                    await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
