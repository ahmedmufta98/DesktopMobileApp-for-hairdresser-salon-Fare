using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.MobileUI.Views;
using eHairdresserSalonFare.Model.Requests.Payment;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class PaymentViewModel : BaseViewModel
    {
        private readonly BaseAPIService _paymentApiService = new BaseAPIService("payments");

        public PaymentViewModel()
        {
            PayCommand = new Command(async () => await AddPayment());
        }

        DateTime _paymentDate = new DateTime();
        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set { SetProperty(ref _paymentDate, value); }
        }

        float _price;
        public float Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        string _purpose = string.Empty;
        public string Purpose
        {
            get { return _purpose; }
            set { SetProperty(ref _purpose, value); }
        }

        string _client=string.Empty;
        public string Client
        {
            get { return _client; }
            set { SetProperty(ref _client, value); }
        }

        string _bankCardNumber = string.Empty;
        public string BankCardNumber
        {
            get { return _bankCardNumber; }
            set { SetProperty(ref _bankCardNumber, value); }
        }

        public ICommand PayCommand { get; set; }

        async Task AddPayment()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(BankCardNumber))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Bank card number field is required !", "OK");
                    return;
                }

                if (BankCardNumber.Length!=11)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Bank card number contain 11 numbers !", "OK");
                    return;
                }

                PaymentUpsertRequest payment = new PaymentUpsertRequest
                {
                    PaymentDate = PaymentDate,
                    Amount = Price,
                    UserId = BaseAPIService.Id,
                    BankCardNumber = BankCardNumber
                };

                Model.Payment newPayment = await _paymentApiService.Insert<Model.Payment>(payment);

                if (newPayment != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Success payment!", "OK");
                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Warning", "Failed payment!", "OK");
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
