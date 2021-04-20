using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.User;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eHairdresserSalonFare.MobileUI.APIServices
{
    public class UserAPIService : BaseAPIService
    {
        private readonly string _route = null;

#if DEBUG
        private readonly string _apiUrl = "http://localhost:63982/api";
#endif
#if RELEASE
        private string _apiUrl = "https://mywebsite.azure.com/api/";
#endif

        public UserAPIService(string route) : base(route)
        {
            _route = route;
        }

        public async Task<Model.User> Login(UserLoginRequest request)
        {
            var url = $"{_apiUrl}/{_route}/login";
            return await url.PostJsonAsync(request).ReceiveJson<Model.User>();
        }

        public async Task<Model.User> Register(UserUpsertRequest request)
        {
             var url = $"{_apiUrl}/{_route}/register";
             return await url.PostJsonAsync(request).ReceiveJson<Model.User>(); 
        }

        public async Task<List<Model.Payment>> GetPaymentsOfUser(int userId)
        {
            var url = $"{_apiUrl}/{_route}/{userId}/payments";
            return await url.WithBasicAuth(Username, Password).GetJsonAsync<List<Model.Payment>>();
        }

        public async Task<Model.User> GetByUsername(UserLoginRequest request)
        {
            var url = $"{_apiUrl}/{_route}/username";
            if (request != null)
            {
                url += "?";
                url += await request.ToQueryString();
            }

            return await url.GetJsonAsync<Model.User>();
        }
    }
}
