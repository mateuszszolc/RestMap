using Newtonsoft.Json;
using RestMap.Interfaces;
using RestMap.Settings;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Android.Net;
using Xamarin.Forms.PlatformConfiguration;

namespace RestMap.Model.Zomato.API_Service
{
    public class ZomatoClient : IZomatoClient
    {
        private readonly HttpClient _client;

        public ZomatoClient()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(ZomatoSettings.BASE_URL)
            };
            _client.DefaultRequestHeaders.Add(ZomatoSettings.HEADER, ZomatoSettings.API_KEY);
        }
        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _client.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                    return default(T);

                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
