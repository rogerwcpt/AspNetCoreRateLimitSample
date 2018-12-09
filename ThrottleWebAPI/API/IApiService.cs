using System.Threading.Tasks;

namespace ThrottleWebAPI.API
{
    public interface IApiService
    {
        Task<string> DoWorkAsync(string value);
    }
}