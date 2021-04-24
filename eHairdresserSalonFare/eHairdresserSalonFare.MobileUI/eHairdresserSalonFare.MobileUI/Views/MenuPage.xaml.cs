using eHairdresserSalonFare.MobileUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Profile, Title="Your profile" },
                new HomeMenuItem {Id = MenuItemType.Notifications, Title="Notifications" },
                new HomeMenuItem {Id = MenuItemType.Sponsors, Title="Sponsors" },
                new HomeMenuItem {Id = MenuItemType.Hairstyles, Title="Hairstyles in our offer" },
                new HomeMenuItem {Id = MenuItemType.Hairdressers, Title="Hairdressers" },
                new HomeMenuItem {Id = MenuItemType.RatingHairdressers, Title="Rate your hairdressers" },
                new HomeMenuItem {Id = MenuItemType.Forum, Title="Forum" },
                new HomeMenuItem {Id = MenuItemType.PaymentsHistory, Title="Your payments" },
                new HomeMenuItem {Id = MenuItemType.Logout, Title="Log out" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}