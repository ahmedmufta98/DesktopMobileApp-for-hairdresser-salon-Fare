using System;
using System.Collections.Generic;
using System.Text;

namespace eHairdresserSalonFare.MobileUI.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Profile,
        Notifications,
        Sponsors,
        Hairstyles,
        Hairdressers,
        RatingHairdressers,
        Forum,
        PaymentsHistory,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
