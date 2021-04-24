using eHairdresserSalonFare.MobileUI.ViewModels;
using eHairdresserSalonFare.Model.DTO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eHairdresserSalonFare.MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentPage : ContentPage
    {
        private PaymentViewModel model = null;
        public PaymentPage(PaymentDto paymentData)
        {
            InitializeComponent();
            model = new PaymentViewModel();
            model.PaymentDate = paymentData.PaymentDate;
            model.Purpose = paymentData.Purpose;
            model.Client = paymentData.ClientName;
            model.Price = paymentData.Price;
            BindingContext = model;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}