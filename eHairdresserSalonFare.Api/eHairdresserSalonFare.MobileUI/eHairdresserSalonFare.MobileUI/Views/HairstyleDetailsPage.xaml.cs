using eHairdresserSalonFare.MobileUI.ViewModels;
using eHairdresserSalonFare.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eHairdresserSalonFare.MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HairstyleDetailsPage : ContentPage
    {
        private HairstyleDetailsViewModel model = null;
        public HairstyleDetailsPage(Hairstyle hairstyle)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);

            BindingContext = model = new HairstyleDetailsViewModel
            {
                _hairstyle = hairstyle
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Initialization();
        }
    }
}