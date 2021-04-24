using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.Model;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class PaymentHistoryDetailsViewModel : BaseViewModel
    {
        private readonly BaseAPIService _apiService = new BaseAPIService("payments");
        public Payment _payment { get; set; } = null;
        public ICommand InitCommand { get; set; }

        public PaymentHistoryDetailsViewModel()
        {
            InitCommand = new Command(async () => await Initialization());
        }

        private string _client = string.Empty;
        public string Client
        {
            get { return _client; }
            set { SetProperty(ref _client, value); }
        }

        private string _bankCardNumber = string.Empty;
        public string BankCardNumber
        {
            get { return _bankCardNumber; }
            set { SetProperty(ref _bankCardNumber, value); }
        }

        private float _amount;
        public float Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }

        private DateTime _paymentDate;
        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set { SetProperty(ref _paymentDate, value); }
        }

        public async Task Initialization()
        {
            _payment = await _apiService.GetById<Payment>(_payment.Id);
            BankCardNumber = _payment.BankCardNumber;
            PaymentDate = _payment.PaymentDate;
            Amount = _payment.Amount;
            Client = BaseAPIService.Fullname;
        }
    }
}
