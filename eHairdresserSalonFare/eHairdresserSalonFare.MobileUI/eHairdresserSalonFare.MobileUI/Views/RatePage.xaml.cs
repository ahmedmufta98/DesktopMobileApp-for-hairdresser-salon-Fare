using eHairdresserSalonFare.MobileUI.ViewModels;
using eHairdresserSalonFare.Model.DTO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eHairdresserSalonFare.MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatePage : ContentPage
    {
        private RateViewModel model = null;

        public RatePage(RatingHairdresserDto ratingHairdresser)
        {
            InitializeComponent();
            model = new RateViewModel();
            model.HairdresserId = ratingHairdresser.HairdresserId;
            model.FirstName = ratingHairdresser.FirstName;
            model.LastName = ratingHairdresser.LastName;
            model.Email = ratingHairdresser.Email;
            model.Phone = ratingHairdresser.Phone;
            model.Image = ratingHairdresser.Image;

            BindingContext = model;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}