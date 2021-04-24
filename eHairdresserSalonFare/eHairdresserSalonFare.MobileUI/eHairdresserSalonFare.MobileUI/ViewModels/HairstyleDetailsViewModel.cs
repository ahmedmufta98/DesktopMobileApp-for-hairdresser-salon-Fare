using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.Model;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class HairstyleDetailsViewModel : BaseViewModel
    {
        public Hairstyle _hairstyle { get; set; } = null;

        private readonly BaseAPIService _apiService = new BaseAPIService("hairstyles");
        public ICommand InitCommand { get; set; }
        public HairstyleDetailsViewModel()
        {
            InitCommand = new Command(async () => await Initialization());
        }

        private string _hairstyleName = string.Empty;
        public string HairstyleName
        {
            get { return _hairstyleName; }
            set { SetProperty(ref _hairstyleName, value); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private float _price;
        public float Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        private int _durationOfProduction;
        public int DurationOfProduction
        {
            get { return _durationOfProduction; }
            set { SetProperty(ref _durationOfProduction, value); }
        }

        private byte[] _image;

        public byte[] Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        public async Task Initialization()
        {
            _hairstyle = await _apiService.GetById<Hairstyle>(_hairstyle.Id);

            if (_hairstyle != null)
            {
                HairstyleName = _hairstyle.HairstyleName;
                Description = _hairstyle.Description;
                Image = _hairstyle.Image;
                Price = _hairstyle.Price;
                DurationOfProduction = _hairstyle.DurationOfProduction;
            }
        }
    }
}
