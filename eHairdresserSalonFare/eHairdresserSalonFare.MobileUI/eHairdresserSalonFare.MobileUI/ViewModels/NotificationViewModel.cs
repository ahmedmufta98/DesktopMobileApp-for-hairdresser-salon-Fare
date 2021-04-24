using eHairdresserSalonFare.MobileUI.APIServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class NotificationViewModel
    {
        private readonly BaseAPIService _notificationApiService = new BaseAPIService("notifications");

        public NotificationViewModel()
        {
            InitCommand = new Command(async () => await Init());

        }

        public ICommand InitCommand { get; set; }
        public ObservableCollection<Model.Notification> _notifications { get; set; } = new ObservableCollection<Model.Notification>();

        public async Task Init()
        {
            List<Model.Notification> _notificationslist = await _notificationApiService.GetAll<List<Model.Notification>>(null);
            _notifications.Clear();

            foreach (var item in _notificationslist)
            {
                _notifications.Add(item);
            }
        }
    }
}
