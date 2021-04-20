using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.MobileUI.ViewModels;
using eHairdresserSalonFare.Model.Requests.User;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eHairdresserSalonFare.MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private ProfileViewModel model = null;
        private UserAPIService _apiService = new UserAPIService("users");
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = model = new ProfileViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(model.FirstName==null || model.FirstName=="" || model.LastName==null || model.LastName=="" || model.Email==null || model.Email==""
                || model.Phone==null || model.Phone=="" || model.Username==null || model.Username == "")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "All fields are required!", "OK");
                return;
            }

            Model.User user = await _apiService.GetById<Model.User>(BaseAPIService.Id);
            if (user != null)
            {
                UserUpsertRequest request = new UserUpsertRequest()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Username = model.Username,
                    Phone = model.Phone,
                    RoleId = user.RoleId,
                    Image = user.Image
                };
                Model.User updatedUser=await _apiService.Update<Model.User>(user.Id,request);
                if (updatedUser != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Successfuly updated data! Now, just log in.", "OK");
                    await Navigation.PushAsync(new LoginPage());
                }
            }
        }
    }
}