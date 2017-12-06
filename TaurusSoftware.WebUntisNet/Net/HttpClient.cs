using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace TaurusSoftware.WebUntisNet.Net
{
    public class HttpClient : IHttpClient
    {
        public async Task<string> SendAsync(Uri uri, string request, string sessionId, int timeOut, CancellationToken token = default(CancellationToken))
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            if (!string.IsNullOrWhiteSpace(sessionId))
            {
                if (httpWebRequest.CookieContainer == null)
                {
                    httpWebRequest.CookieContainer = new CookieContainer();
                }

                if (!string.IsNullOrWhiteSpace(sessionId))
                {
                    httpWebRequest.CookieContainer.Add(new Cookie("JSESSIONID", sessionId, "/", uri.Host));
                }
            }


            using (StreamWriter streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
            {
                await streamWriter.WriteAsync(request);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync(TimeSpan.FromSeconds(timeOut));
            var responseStream = httpResponse.GetResponseStream();
            if (responseStream == null)
            {
                throw new IOException("response stream was null!");
            }

            string result;
            using (StreamReader streamReader = new StreamReader(responseStream))
            {
                result = await streamReader.ReadToEndAsync();
            }

            return result;
        }
    }
}
