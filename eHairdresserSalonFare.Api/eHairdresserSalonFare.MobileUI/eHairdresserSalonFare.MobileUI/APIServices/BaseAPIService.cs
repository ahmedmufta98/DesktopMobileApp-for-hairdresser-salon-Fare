using eHairdresserSalonFare.Model;
using Flurl.Http;
using System.Threading.Tasks;

namespace eHairdresserSalonFare.MobileUI.APIServices
{
    public class BaseAPIService
    {
        private readonly string _route = null;
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Fullname { get; set; }
        public static int Id { get; set; }


#if DEBUG
        private readonly string _apiUrl = "http://localhost:63982/api";
#endif
#if RELEASE
        private string _apiUrl = "https://mywebsite.azure.com/api/";
#endif

        public BaseAPIService(string route)
        {
            _route = route;
        }

        public async Task<T> GetAll<T>(object search)
        {
            var url = $"{_apiUrl}/{_route}";
            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl}/{_route}";
            return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{_apiUrl}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Delete<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
        }
    }
}
