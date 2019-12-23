using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication1.Proxy
{
    public class Service1Proxy : IService1
    {
        private readonly HttpClient _client;

        public Service1Proxy(HttpClient client)
        {
            _client = client;
        }

        public async Task GetAsync()
        {
            var response = await _client.GetAsync("https://localhost:5001/Service1");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new System.Exception($"{response.ReasonPhrase}: {error}");
            }
        }

        public async Task PostAsync(HttpContent content)
        {
            var response = await _client.PostAsync("https://localhost:5001/Service1", content);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new System.Exception($"{response.ReasonPhrase}: {error}");
            }
        }
    }
}
