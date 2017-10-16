using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using WebUntisNet.Rpc.Types;

namespace WebUntisNet.Rpc
{
    public class RpcClient : IRpcClient
    {
        private readonly Uri _serviceUri;

        public RpcClient(string serviceUrl)
        {
            if (string.IsNullOrEmpty(serviceUrl))
            {
                throw new ArgumentException("no service url specified", nameof(serviceUrl));
            }

            _serviceUri = new Uri(serviceUrl);
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(string schoolName, AuthenticationRequest request)
        {
            if (string.IsNullOrEmpty(schoolName))
            {
                throw new ArgumentException("no schoolname specified", nameof(schoolName));
            }

            var uriBuilder = new UriBuilder(_serviceUri);
            
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["school"] = schoolName;
            uriBuilder.Query = query.ToString();
            var requestUri = uriBuilder.Uri;

            return await SendAsync<AuthenticationRequest, AuthenticationResponse>(requestUri, request, null);
        }

        private static async Task<string> SendAsync(Uri uri, string request, string sessionId)
        {
            
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
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

            HttpWebResponse httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
            Stream responseStream = httpResponse.GetResponseStream();
            if (responseStream == null)
            {
                throw new RpcException("response stream was null!");
            }

            string result;
            using (StreamReader streamReader = new StreamReader(responseStream))
            {
                result = await streamReader.ReadToEndAsync();
            }

            return result;
        }


        private static async Task<TResult> SendAsync<TRequest, TResult>(Uri uri, TRequest request, string sessionId) 
            where TRequest : RpcRequest 
            where TResult : RpcResponse
        {
            string requestText = JsonConvert.SerializeObject(request);
            string responseText = await SendAsync(uri, requestText, null);

            if (responseText.Contains("<!DOCTYPE html>"))
            {
                throw new RpcException("The service url is invalid, server responded with HTML!");
            }


            var result = JsonConvert.DeserializeObject<TResult>(responseText);

            string errorMsg = result.error?.message;
            if (!string.IsNullOrEmpty(errorMsg))
            {
                throw new RpcException(errorMsg);
            }

            return result;
        }
    }


}