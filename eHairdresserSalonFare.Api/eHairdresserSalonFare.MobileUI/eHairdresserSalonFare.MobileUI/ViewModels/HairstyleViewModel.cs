using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.Hairstyle;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class HairstyleViewModel : BaseViewModel
    {
        private readonly BaseAPIService _apiService = new BaseAPIService("hairstyles");

        public ICommand InitCommand { get; set; }
        public ICommand SearchHairstyle { get; set; }
        public ObservableCollection<Hairstyle> _hairstyles { get; set; } = new ObservableCollection<Hairstyle>();

        public HairstyleViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SearchHairstyle = new Command(async () => await Search());
        }

        string _hairstyleName = string.Empty;
        public string HairstyleName
        {
            get { return _hairstyleName; }
            set { SetProperty(ref _hairstyleName, value); }
        }

        public async Task Init()
        {
            List<Hairstyle> _hairstylesList = await _apiService.GetAll<List<Hairstyle>>(null);
            _hairstyles.Clear();

            foreach (var item in _hairstylesList)
            {
                _hairstyles.Add(item);
            }
        }

        public async Task Search()
        {
            List<Model.Hairstyle> _hairstylesList = new List<Model.Hairstyle>();
           
            if (HairstyleName==null || HairstyleName == "")
            {
                _hairstylesList = await _apiService.GetAll<List<Model.Hairstyle>>(null);
            }
            else
            {
                HairstyleSearchRequest request = new HairstyleSearchRequest
                {
                    HairstyleName = HairstyleName
                };
                _hairstylesList = await _apiService.GetAll<List<Model.Hairstyle>>(request);
            }

            if (_hairstyles.Count > 0)
            {
                _hairstyles.Clear();
            }
            
            if(_hairstylesList.Count==0)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "No results found for this filter!", "OK");
                return;
            }

            foreach (var item in _hairstylesList)
            {
                _hairstyles.Add(item);
            }
        }
    }
}
