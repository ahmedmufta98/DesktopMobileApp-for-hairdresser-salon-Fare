using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.Model;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class SponsorDetailViewModel : BaseViewModel
    {
        private readonly BaseAPIService _apiService = new BaseAPIService("sponsors");
        public Sponsor _sponsor { get; set; } = null;
        public ICommand InitCommand { get; set; }

        public SponsorDetailViewModel()
        {
            InitCommand = new Command(async () => await Initialization());
        }

        private string _sponsorName = string.Empty;
        public string SponsorName
        {
            get { return _sponsorName; }
            set { SetProperty(ref _sponsorName, value); }
        }

        private string _about = string.Empty;
        public string About
        {
            get { return _about; }
            set { SetProperty(ref _about, value); }
        }

        private byte[] _logo;

        public byte[] Logo
        {
            get { return _logo; }
            set { SetProperty(ref _logo, value); }
        }

        public async Task Initialization()
        {
            _sponsor = await _apiService.GetById<Sponsor>(_sponsor.Id);

            SponsorName = _sponsor.SponsorName;
            About = _sponsor.About;
            Logo = _sponsor.Logo;
        }
    }
}
