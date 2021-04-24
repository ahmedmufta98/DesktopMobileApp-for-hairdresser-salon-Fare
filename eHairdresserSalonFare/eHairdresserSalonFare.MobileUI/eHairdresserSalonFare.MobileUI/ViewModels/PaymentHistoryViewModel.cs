using eHairdresserSalonFare.MobileUI.APIServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class PaymentHistoryViewModel
    {
        private readonly UserAPIService _userApiService = new UserAPIService("users");

        public PaymentHistoryViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ICommand InitCommand { get; set; }
        public ObservableCollection<Model.Payment> _payments { get; set; } = new ObservableCollection<Model.Payment>();

        public async Task Init()
        {
            List<Model.Payment> _paymentsList = await _userApiService.GetPaymentsOfUser(BaseAPIService.Id);
            _payments.Clear();

            foreach (var item in _paymentsList)
            {
                _payments.Add(item);
            }
        }
    }
}
