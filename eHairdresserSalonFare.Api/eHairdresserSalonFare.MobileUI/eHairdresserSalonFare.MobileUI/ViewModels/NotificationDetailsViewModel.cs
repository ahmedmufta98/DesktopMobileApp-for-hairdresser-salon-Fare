using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.Model;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class NotificationDetailsViewModel : BaseViewModel
    {
        private readonly BaseAPIService _apiService = new BaseAPIService("notifications");
        public Notification _notification { get; set; } = null;
        public ICommand InitCommand { get; set; }

        public NotificationDetailsViewModel()
        {
            InitCommand = new Command(async () => await Initialization());
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _text = string.Empty;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private DateTime _notificationDate = new DateTime();
        public DateTime NotificationDate
        {
            get { return _notificationDate; }
            set { SetProperty(ref _notificationDate, value); }
        }

        public async Task Initialization()
        {
            _notification = await _apiService.GetById<Notification>(_notification.Id);
            Text = _notification.Text;
            Title = _notification.Title;
            NotificationDate = _notification.NotificationDate;
        }
    }
}
