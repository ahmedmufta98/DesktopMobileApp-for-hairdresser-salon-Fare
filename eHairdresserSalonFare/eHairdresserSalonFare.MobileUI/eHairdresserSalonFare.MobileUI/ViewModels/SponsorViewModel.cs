using eHairdresserSalonFare.MobileUI.APIServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class SponsorViewModel
    {
        private readonly BaseAPIService _sponsorApiService = new BaseAPIService("sponsors");

        public ICommand InitCommand { get; set; }
        public ObservableCollection<Model.Sponsor> _sponsors { get; set; } = new ObservableCollection<Model.Sponsor>();

        public SponsorViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public async Task Init()
        {
            List<Model.Sponsor> _sponsorsList = await _sponsorApiService.GetAll<List<Model.Sponsor>>(null);
            _sponsors.Clear();

            foreach (var item in _sponsorsList)
            {
                _sponsors.Add(item);
            }
        }
    }
}
