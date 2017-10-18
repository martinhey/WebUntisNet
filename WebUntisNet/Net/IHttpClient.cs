using System;
using System.Threading.Tasks;

namespace WebUntisNet.Net
{
    public interface IHttpClient
    {
        Task<string> SendAsync(Uri uri, string request, string sessionId, int timeOut);
    }
}