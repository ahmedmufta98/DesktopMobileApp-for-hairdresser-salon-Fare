using eHairdresserSalonFare.MobileUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eHairdresserSalonFare.MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPage : ContentPage
    {
        private BookingViewModel model = null;

        public BookingPage(Model.Hairdresser hairdresser)
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, true);

            BindingContext = model = new BookingViewModel
            {
                _hairdresser = hairdresser
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Initialization();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var clicked_item = e.Item as Model.Hairdresser;
            if (clicked_item.Available == false)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "This hairdresser is currently unavailable! Please select another hairdresser.", "OK");
                return;
            }
            await Navigation.PushAsync(new BookingPage(clicked_item));
        }
    }
}