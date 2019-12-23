using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication2.Proxy
{
    public interface IService2
    {
        Task GetAsync();

        Task PostAsync(HttpContent content);
    }
}
