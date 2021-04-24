using eHairdresserSalonFare.MobileUI.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Profile:
                        MenuPages.Add(id, new NavigationPage(new ProfilePage()));
                        break;
                    case (int)MenuItemType.Notifications:
                        MenuPages.Add(id, new NavigationPage(new NotificationsPage()));
                        break;
                    case (int)MenuItemType.Sponsors:
                        MenuPages.Add(id, new NavigationPage(new SponsorsPage()));
                        break;
                    case (int)MenuItemType.Hairstyles:
                        MenuPages.Add(id, new NavigationPage(new HairstylesPage()));
                        break;
                    case (int)MenuItemType.Hairdressers:
                        MenuPages.Add(id, new NavigationPage(new HairdressersPage()));
                        break;
                    case (int)MenuItemType.RatingHairdressers:
                        MenuPages.Add(id, new NavigationPage(new RatingHairdressersPage()));
                        break;
                    case (int)MenuItemType.Forum:
                        MenuPages.Add(id, new NavigationPage(new ForumPage()));
                        break;
                    case (int)MenuItemType.PaymentsHistory:
                        MenuPages.Add(id, new NavigationPage(new PaymentHistoryPage()));
                        break;
                    case (int)MenuItemType.Logout:
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}