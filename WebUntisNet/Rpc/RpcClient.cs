using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Web;
using WebUntisNet.Net;
using WebUntisNet.Rpc.Types;

namespace WebUntisNet.Rpc
{
    /// <summary>
    /// Rpc client based on untis JSON-RPC API version 4.10.2016
    /// </summary>
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

        /// <inheritdoc cref="IRpcClient"/>
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

        /// <inheritdoc cref="IRpcClient"/>
        public Task<EmptyResponse> LogoutAsync(LogoutRequest request, string sessionId)
        {
            return SendAsync<LogoutRequest, EmptyResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
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

        /// <inheritdoc cref="IRpcClient"/>
        public Task<StudentsResponse> GetStudentsAsync(StudentsRequest request, string sessionId)
        {
            return SendAsync<StudentsRequest, StudentsResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<ClassesResponse> GetClassesAsync(ClassesRequest request, string sessionId)
        {
            return SendAsync<ClassesRequest, ClassesResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<SubjectsResponse> GetSubjectsAsync(SubjectsRequest request, string sessionId)
        {
            return SendAsync<SubjectsRequest, SubjectsResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<RoomsResponse> GetRoomsAsync(RoomsRequest request, string sessionId)
        {
            return SendAsync<RoomsRequest, RoomsResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<DepartmentsResponse> GetDepartmentsAsync(DepartmentsRequest request, string sessionId)
        {
            return SendAsync<DepartmentsRequest, DepartmentsResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<HolidaysResponse> GetHolidaysAsync(HolidaysRequest request, string sessionId)
        {
            return SendAsync<HolidaysRequest, HolidaysResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<TimegridResponse> GetTimegridAsync(TimegridRequest request, string sessionId)
        {
            return SendAsync<TimegridRequest, TimegridResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<StatusDataResponse> GetStatusDataAsync(StatusDataRequest request, string sessionId)
        {
            return SendAsync<StatusDataRequest, StatusDataResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<SchoolYearsResponse> GetCurrentSchoolYearAsync(CurrentSchoolYearRequest request, string sessionId)
        {
            return SendAsync<CurrentSchoolYearRequest, SchoolYearsResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<SchoolYearsResponse> GetSchoolYearsAsync(SchoolYearsRequest request, string sessionId)
        {
            return SendAsync<SchoolYearsRequest, SchoolYearsResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<TimetableResponse> GetTimetableAsync(SimpleTimetableRequest request, string sessionId)
        {
            return SendAsync<SimpleTimetableRequest, TimetableResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<ExamTypesResponse> GetExamTypesAsync(ExamTypesRequest request, string sessionId)
        {
            return SendAsync<ExamTypesRequest, ExamTypesResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<ExamsResponse> GetExamsAsync(ExamsRequest request, string sessionId)
        {
            return SendAsync<ExamsRequest, ExamsResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<ClassregEventsResponse> GetClassregEventsAsync(ClassregEventsRequest request, string sessionId)
        {
            return SendAsync<ClassregEventsRequest, ClassregEventsResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<SubstitutionsResponse> GetSubstitutionsAsync(SubstitutionsRequest request, string sessionId)
        {
            return SendAsync<SubstitutionsRequest, SubstitutionsResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<PersonIdResponse> GetPersonIdAsync(PersonIdRequest request, string sessionId)
        {
            return SendAsync<PersonIdRequest, PersonIdResponse>(_serviceUri, request, sessionId);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<LatestImportTimeResponse> GetLatestImportTimeAsync(LatestImportTimeRequest request, string sessionId)
        {
            return SendAsync<LatestImportTimeRequest, LatestImportTimeResponse>(_serviceUri, request, sessionId);
        }
    }
}