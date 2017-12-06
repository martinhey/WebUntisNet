using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaurusSoftware.WebUntisNet.Net
{
    public interface IHttpClient
    {
        Task<string> SendAsync(Uri uri, string request, string sessionId, int timeOut, CancellationToken token = default(CancellationToken));
    }
}