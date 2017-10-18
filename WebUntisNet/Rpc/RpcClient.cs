using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using WebUntisNet.Net;
using WebUntisNet.Rpc.Types;

namespace WebUntisNet.Rpc
{
    public class RpcClient : IRpcClient
    {
        private readonly IHttpClient _httpClient;
        private readonly Uri _serviceUri;

        public RpcClient(IHttpClient httpClient, string serviceUrl)
        {
            if (string.IsNullOrEmpty(serviceUrl))
            {
                throw new ArgumentException("no service url specified", nameof(serviceUrl));
            }
            _httpClient = httpClient;

            _serviceUri = new Uri(serviceUrl);
            Timeout = 30;
        }

        public int Timeout { get; set; }

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

        public Task<EmptyResponse> LogoutAsync(LogoutRequest request, string sessionId)
        {
            return SendAsync<LogoutRequest, EmptyResponse>(_serviceUri, request, sessionId);
        }

        public Task<TeachersResponse> GetTeachersAsync(TeachersRequest request, string sessionId)
        {
            return SendAsync<TeachersRequest, TeachersResponse>(_serviceUri, request, sessionId);
        }

        private Task<string> SendAsync(Uri uri, string request, string sessionId)
        {
            return _httpClient.SendAsync(uri, request, sessionId, Timeout);
        }


        private async Task<TResult> SendAsync<TRequest, TResult>(Uri uri, TRequest request, string sessionId) 
            where TRequest : IRpcRequest 
            where TResult : IRpcResponse
        {
            string requestText = JsonConvert.SerializeObject(request);
            string responseText = await SendAsync(uri, requestText, sessionId);

            if (responseText.Contains("<!DOCTYPE html>"))
            {
                throw new RpcException("The service url is invalid, server responded with HTML!");
            }


            return JsonConvert.DeserializeObject<TResult>(responseText);
        }

        public Task<StudentsResponse> GetStudentsAsync(StudentsRequest request, string sessionId)
        {
            return SendAsync<StudentsRequest, StudentsResponse>(_serviceUri, request, sessionId);
        }

        public Task<ClassesResponse> GetClassesAsync(ClassesRequest request, string sessionId)
        {
            return SendAsync<ClassesRequest, ClassesResponse>(_serviceUri, request, sessionId);
        }
    }


}