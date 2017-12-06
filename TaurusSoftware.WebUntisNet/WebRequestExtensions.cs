using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace TaurusSoftware.WebUntisNet
{
    internal static class WebRequestExtensions
    {
        internal static Task<WebResponse> GetResponseAsync(this WebRequest request, TimeSpan timeout, CancellationToken token = default(CancellationToken))
        {
            // TODO: handle cancellation token
            var t = Task.Factory.FromAsync(
                request.BeginGetResponse,
                request.EndGetResponse,
                null);
            return Task.Factory.StartNew(() =>
            {
                if (!t.Wait(timeout)) throw new TimeoutException();

                return t.Result;
            });
        }
    }
}
