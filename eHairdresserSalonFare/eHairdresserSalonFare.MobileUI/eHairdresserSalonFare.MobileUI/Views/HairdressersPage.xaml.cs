using eHairdresserSalonFare.MobileUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eHairdresserSalonFare.MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HairdressersPage : ContentPage
    {
        private readonly HairdresserViewModel model = null;

        public HairdressersPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);

            BindingContext = model = new HairdresserViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
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