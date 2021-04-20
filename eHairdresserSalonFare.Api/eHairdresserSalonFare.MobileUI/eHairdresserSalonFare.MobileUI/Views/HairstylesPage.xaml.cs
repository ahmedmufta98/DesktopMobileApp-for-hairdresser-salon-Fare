using eHairdresserSalonFare.MobileUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eHairdresserSalonFare.MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HairstylesPage : ContentPage
    {
        private readonly HairstyleViewModel model = null;

        public HairstylesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);

            BindingContext = model = new HairstyleViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var clicked_item = e.Item as Model.Hairstyle;

            await Navigation.PushAsync(new HairstyleDetailsPage(clicked_item));
        }
    }
}