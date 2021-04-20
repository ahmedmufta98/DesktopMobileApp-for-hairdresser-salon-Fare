using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.MobileUI.ViewModels;
using eHairdresserSalonFare.Model.DTO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eHairdresserSalonFare.MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatingHairdressersPage : ContentPage
    {
        private readonly HairdresserRatingViewModel model = null;

        public RatingHairdressersPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);

            BindingContext = model = new HairdresserRatingViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var clicked_item = e.Item as Model.Hairdresser;
            RatingHairdresserDto _ratingHairdresser = new RatingHairdresserDto
            {
                HairdresserId = clicked_item.Id,
                FirstName = clicked_item.FirstName,
                LastName = clicked_item.LastName,
                Email = clicked_item.Email,
                Phone = clicked_item.Phone,
                Image = clicked_item.Image,
                UserId = BaseAPIService.Id
            };

            await Navigation.PushAsync(new RatePage(_ratingHairdresser));
        }
    }
}