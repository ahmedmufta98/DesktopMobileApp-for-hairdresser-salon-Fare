using System;

using eHairdresserSalonFare.MobileUI.Models;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
