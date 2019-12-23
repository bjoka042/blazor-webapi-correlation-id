using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication2.Proxy
{
    public class Service2Proxy : IService2
    {
        private readonly HttpClient _client;

        public Service2Proxy(HttpClient client)
        {
            _client = client;
        }

        public async Task GetAsync()
        {
            var response = await _client.GetAsync("https://localhost:5002/Service2");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new System.Exception($"{response.ReasonPhrase}: {error}");
            }

        }

        public async Task PostAsync(HttpContent content)
        {
            var response = await _client.PostAsync("https://localhost:5002/Service2", content);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new System.Exception($"{response.ReasonPhrase}: {error}");
            }
        }
    }
}
