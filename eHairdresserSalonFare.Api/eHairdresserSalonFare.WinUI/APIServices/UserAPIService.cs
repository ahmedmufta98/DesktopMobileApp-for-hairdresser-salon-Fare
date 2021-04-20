using eHairdresserSalonFare.Model.Requests.User;
using Flurl.Http;
using System.Threading.Tasks;
using eHairdresserSalonFare.Model;

namespace eHairdresserSalonFare.WinUI.APIServices
{
    public class UserAPIService : BaseAPIService
    {
        private readonly string _route=null;
        public UserAPIService(string route) : base(route)
        {
            _route = route;
        }

        public async Task<Model.User> Login(UserLoginRequest request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/login";
            return await url.PostJsonAsync(request).ReceiveJson<Model.User>();
        }

        public async Task<Model.User> Register(object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/register";
            return await url.PostJsonAsync(request).ReceiveJson<Model.User>();
        }

        public async Task<Model.User> GetByUsername(UserLoginRequest request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/username";
            if (request != null)
            {
                url += "?";
                url += await request.ToQueryString();
            }

            return await url.GetJsonAsync<Model.User>();
        }
    }
}
