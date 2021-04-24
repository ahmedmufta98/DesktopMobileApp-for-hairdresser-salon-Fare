using eHairdresserSalonFare.MobileUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eHairdresserSalonFare.MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentHistoryDetailsPage : ContentPage
    {
        private PaymentHistoryDetailsViewModel model = null;

        public PaymentHistoryDetailsPage(Model.Payment payment)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);

            BindingContext = model = new PaymentHistoryDetailsViewModel
            {
                _payment = payment
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Initialization();
        }
    }
}