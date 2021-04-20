using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eHairdresserSalonFare.MobileUI.APIServices
{
    public class HairdresserHairstyleAPIService
    {
        private readonly string _apiUrl = "http://localhost:63982/api";

        public HairdresserHairstyleAPIService()
        {}

        public async Task<List<Model.Hairstyle>> FindAllHairstylesOfHairdresser(int hairdresserId)
        {
            var url = $"{_apiUrl}/hairdressers/{hairdresserId}/hairstyles";
            return await url.WithBasicAuth(BaseAPIService.Username, BaseAPIService.Password).GetJsonAsync<List<Model.Hairstyle>>();
        }

        public async Task<List<Model.Hairdresser>> FindHairdressersOfClientForRating(int clientId)
        {
            var url = $"{_apiUrl}/hairdressers/{clientId}/ratinghairdressers";
            return await url.WithBasicAuth(BaseAPIService.Username, BaseAPIService.Password).GetJsonAsync<List<Model.Hairdresser>>();
        }
    }
}
