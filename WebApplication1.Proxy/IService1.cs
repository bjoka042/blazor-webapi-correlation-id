using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication1.Proxy
{
    public interface IService1
    {
        Task GetAsync();

        Task PostAsync(HttpContent content);
    }
}
