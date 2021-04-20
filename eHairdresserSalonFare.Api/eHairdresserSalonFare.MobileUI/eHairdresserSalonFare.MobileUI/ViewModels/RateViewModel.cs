using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.MobileUI.Views;
using eHairdresserSalonFare.Model.Requests.Rating;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class RateViewModel : BaseViewModel
    {
        private readonly BaseAPIService _apiService = new BaseAPIService("ratings");
        public ICommand RateCommand { get; set; }

        public RateViewModel()
        {
            RateCommand = new Command(async () => await Rating());
        }

        int _hairdresserId;
        public int HairdresserId
        {
            get { return _hairdresserId; }
            set { SetProperty(ref _hairdresserId, value); }
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

        byte[] _image;
        public byte[] Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        int _rate = 0;
        public int Rate
        {
            get { return _rate; }
            set { SetProperty(ref _rate, value); }
        }

        async Task Rating()
        {
            if (Rate<1 || Rate>5)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Rate value must be 1-5!", "OK");
                return;
            }

            RatingInsertRequest rating = new RatingInsertRequest
            {
                UserId = BaseAPIService.Id,
                HairdresserId = HairdresserId,
                Rate = Rate
            };

            Model.Rating newRating = await _apiService.Insert<Model.Rating>(rating);

            if (newRating != null)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "You rate your hairdresser!", "OK");
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Failed rating!", "OK");
                return;
            }
        }
    }
}
