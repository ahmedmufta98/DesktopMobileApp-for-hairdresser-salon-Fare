using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eHairdresserSalonFare.WinUI.APIServices
{
    public class HairdresserHairstyleAPIService
    {
        public HairdresserHairstyleAPIService()
        {}

        public async Task<Model.HairdresserHairstyle> Insert(int hairdresserId, List<int> hairstyleIds)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/hairdressers/{hairdresserId}/hairstyles";
            return await url.WithBasicAuth(BaseAPIService.Username, BaseAPIService.Password).PostJsonAsync(hairstyleIds).ReceiveJson<Model.HairdresserHairstyle>();
        }
    }
}
