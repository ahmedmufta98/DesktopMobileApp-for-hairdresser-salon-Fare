using eHairdresserSalonFare.MobileUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eHairdresserSalonFare.MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SponsorDetailsPage : ContentPage
    {
        private SponsorDetailViewModel model = null;

        public SponsorDetailsPage(Model.Sponsor sponsor)
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, true);

            BindingContext = model = new SponsorDetailViewModel
            {
                _sponsor = sponsor
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Initialization();
        }
    }
}