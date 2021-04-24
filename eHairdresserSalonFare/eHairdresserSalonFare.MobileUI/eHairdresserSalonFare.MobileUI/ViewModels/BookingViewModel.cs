using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.MobileUI.Views;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.DTO;
using eHairdresserSalonFare.Model.Requests.Booking;
using eHairdresserSalonFare.Model.Requests.Hairdresser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class BookingViewModel : BaseViewModel
    {
        private readonly BaseAPIService _hairdresserApiService = new BaseAPIService("hairdressers");
        private readonly BaseAPIService _recommendedApiService = new BaseAPIService("recommendations");
        private readonly HairdresserHairstyleAPIService _hairdresserHairstyleApiService = new HairdresserHairstyleAPIService();
        private readonly BaseAPIService _bookingApiService = new BaseAPIService("bookings");
        private readonly UserAPIService _userApiService = new UserAPIService("users");

        public Hairdresser _hairdresser { get; set; } = null;
        public User _client { get; set; } = null;

        public BookingViewModel()
        {
            InitCommand = new Command(async () => await Initialization());
            BookingCommand = new Command(async () => await Booking());
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

        DateTime _bookingDate;

        public DateTime BookingDate
        {
            get { return _bookingDate; }
            set { SetProperty(ref _bookingDate, value); }
        }

        TimeSpan _bookingTime;
        public TimeSpan BookingTime
        {
            get { return _bookingTime; }
            set { SetProperty(ref _bookingTime, value); }
        }

        public ICommand InitCommand { get; set; }
        public ICommand BookingCommand { get; set; }

        public ObservableCollection<Hairstyle> _hairstyleList { get; set; } = new ObservableCollection<Hairstyle>();

        private Hairstyle _hairstyle = new Hairstyle();

        public Hairstyle SelectedHairstyle
        {
            get { return _hairstyle; }
            set { SetProperty(ref _hairstyle, value); }
        }

        public ObservableCollection<Hairdresser> _recommendedHairdressersList { get; set; } = new ObservableCollection<Hairdresser>();

        public async Task Initialization()
        {
            _client = await _userApiService.GetById<User>(BaseAPIService.Id);
            _hairdresser = await _hairdresserApiService.GetById<Hairdresser>(_hairdresser.Id);
            FirstName = _hairdresser.FirstName;
            LastName = _hairdresser.LastName;
            Email = _hairdresser.Email;
            Phone = _hairdresser.Phone;
            Image = _hairdresser.Image;

            List<Hairstyle> hairstyles = await _hairdresserHairstyleApiService.FindAllHairstylesOfHairdresser(_hairdresser.Id);
            _hairstyleList.Clear();

            foreach(var hairstyle in hairstyles)
            {
                _hairstyleList.Add(hairstyle);
            }

            RecommendedHairdresserSearchRequest request = new RecommendedHairdresserSearchRequest
            {
                HairdresserId = _hairdresser.Id
            };

            List<Hairdresser> recommendedList = await _recommendedApiService.GetAll<List<Hairdresser>>(request);
            _recommendedHairdressersList.Clear();

            foreach (var item in recommendedList)
            {
                _recommendedHairdressersList.Add(item);
            }
        }

        async Task Booking()
        {
            try
            {
                if (SelectedHairstyle == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "You must pick hairstyle which you want!", "OK");
                    return;
                }

                if (BookingTime.Hours < 8 || BookingTime.Hours > 16)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Working hours -> 8:00 AM - 17:00 PM", "OK");
                    return;
                }

                DateTime bookingStart = new DateTime(BookingDate.Year, BookingDate.Month, BookingDate.Day, BookingTime.Hours, BookingTime.Minutes, 0);
                BookingUpsertRequest booking = new BookingUpsertRequest
                {
                    HairdresserId = _hairdresser.Id,
                    HairstyleId = SelectedHairstyle.Id,
                    UserId = _client.Id,
                    StartDate = bookingStart,
                    EndDate = bookingStart.AddMinutes(SelectedHairstyle.DurationOfProduction)
                };

                Model.Booking newBooking = await _bookingApiService.Insert<Model.Booking>(booking);

                if (newBooking != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Booking added!", "OK");
                    if (await Application.Current.MainPage.DisplayAlert("Alert", "Would you like to add payment?", "Yes", "No"))
                    {
                        await Application.Current.MainPage.Navigation.PushModalAsync(new PaymentPage(new PaymentDto
                        {
                            ClientName=_client.FirstName+" "+_client.LastName,
                            Purpose=SelectedHairstyle.HairstyleName,
                            PaymentDate=DateTime.UtcNow,
                            Price=SelectedHairstyle.Price
                        }));
                    }
                    else
                    {
                        Application.Current.MainPage = new MainPage();
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Booking failed! You have chosen a hairdresser who is busy at that time!", "Try again");
                    return;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
