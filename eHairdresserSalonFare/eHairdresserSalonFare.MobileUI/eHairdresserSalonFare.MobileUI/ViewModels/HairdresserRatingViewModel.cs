using eHairdresserSalonFare.MobileUI.APIServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class HairdresserRatingViewModel
    {
        private readonly HairdresserHairstyleAPIService _apiService = new HairdresserHairstyleAPIService();
        public ICommand InitCommand { get; set; }
        public ObservableCollection<Model.Hairdresser> _hairdressersForRatingList { get; set; } = new ObservableCollection<Model.Hairdresser>();

        public HairdresserRatingViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public async Task Init()
        {
            List<Model.Hairdresser> _hairdressers = await _apiService.FindHairdressersOfClientForRating(BaseAPIService.Id);
            _hairdressersForRatingList.Clear();

            foreach (var item in _hairdressers)
            {
                _hairdressersForRatingList.Add(item);
            }
        }
    }
}
