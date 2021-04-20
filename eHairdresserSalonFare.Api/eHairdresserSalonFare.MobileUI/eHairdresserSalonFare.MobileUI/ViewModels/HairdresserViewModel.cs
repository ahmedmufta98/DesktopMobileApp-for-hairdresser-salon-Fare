using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.Model.Requests.Hairdresser;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class HairdresserViewModel : BaseViewModel
    {
        private readonly BaseAPIService _hairdresserApiService = new BaseAPIService("hairdressers");

        public HairdresserViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SearchHairdresser = new Command(async () => await Search());
        }

        public ICommand InitCommand { get; set; }

        public ICommand SearchHairdresser { get; set; }

        string _firstName = string.Empty;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        string _lastName = string.Empty;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        public ObservableCollection<Model.Hairdresser> _hairdressers { get; set; } = new ObservableCollection<Model.Hairdresser>();

        public async Task Init()
        {
            List<Model.Hairdresser> _hairdresserslist = await _hairdresserApiService.GetAll<List<Model.Hairdresser>>(null);
            _hairdressers.Clear();

            foreach (var item in _hairdresserslist)
            {
                _hairdressers.Add(item);
            }
        }

        public async Task Search()
        {
            List<Model.Hairdresser> _hairdressersList = new List<Model.Hairdresser>();

            if ((FirstName==null || FirstName=="") && (LastName==null || LastName == ""))
            {
                _hairdressersList = await _hairdresserApiService.GetAll<List<Model.Hairdresser>>(null);
            }
            else
            {
                HairdresserSearchRequest request = new HairdresserSearchRequest
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Phone = null,
                    Email = null
                };

                _hairdressersList = await _hairdresserApiService.GetAll<List<Model.Hairdresser>>(request);
            }

            if (_hairdressers.Count > 0)
            {
                _hairdressers.Clear();
            }
            
            if(_hairdressersList.Count==0)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "No results found for this filter!", "OK");
                return;
            }

            foreach (var item in _hairdressersList)
            {
                _hairdressers.Add(item);
            }
        }
    }
}
