using eHairdresserSalonFare.MobileUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eHairdresserSalonFare.MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsPage : ContentPage
    {
        private readonly NotificationViewModel model = null;

        public NotificationsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);

            BindingContext = model = new NotificationViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var clicked_item = e.Item as Model.Notification;

            await Navigation.PushAsync(new NotificationDetailsPage(clicked_item));
        }
    }
}