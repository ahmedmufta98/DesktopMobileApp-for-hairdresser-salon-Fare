using eHairdresserSalonFare.MobileUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eHairdresserSalonFare.MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationDetailsPage : ContentPage
    {
        private NotificationDetailsViewModel model = null;

        public NotificationDetailsPage(Model.Notification notification)
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, true);

            BindingContext = model = new NotificationDetailsViewModel
            {
                _notification = notification
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Initialization();
        }
    }
}