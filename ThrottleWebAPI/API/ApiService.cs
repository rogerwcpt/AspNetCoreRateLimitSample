using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Reactive.Linq;
using ThrottleWebAPI.Helpers;
using System.Threading;
namespace ThrottleWebAPI.API
{
    public class ApiService : IApiService
    {

        public Task<string> DoWorkAsync(string value)
        {
            return Task.FromResult($"{value}: {DateTime.Now.ToLongTimeString()}");
        }
    }
}
