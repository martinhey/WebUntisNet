using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TaurusSoftware.WebUntisNet.Net;
using TaurusSoftware.WebUntisNet.Rpc.Types;

namespace TaurusSoftware.WebUntisNet.Rpc
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
        public async Task<AuthenticationResponse> AuthenticateAsync(string schoolName, AuthenticationRequest request, CancellationToken token = default(CancellationToken))
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

            return await SendAsync<AuthenticationRequest, AuthenticationResponse>(requestUri, request, null, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<EmptyResponse> LogoutAsync(LogoutRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<LogoutRequest, EmptyResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<TeachersResponse> GetTeachersAsync(TeachersRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<TeachersRequest, TeachersResponse>(_serviceUri, request, sessionId, token);
        }

        private Task<string> SendAsync(Uri uri, string request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return _httpClient.SendAsync(uri, request, sessionId, Timeout, token);
        }

        private async Task<TResult> SendAsync<TRequest, TResult>(Uri uri, TRequest request, string sessionId, CancellationToken token = default(CancellationToken)) 
            where TRequest : IRpcRequest 
            where TResult : IRpcResponse
        {
            string requestText = JsonConvert.SerializeObject(request);
            string responseText = await SendAsync(uri, requestText, sessionId, token);

            if (responseText.Contains("<!DOCTYPE html>"))
            {
                throw new RpcException("The service url is invalid, server responded with HTML!");
            }


            return JsonConvert.DeserializeObject<TResult>(responseText);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<StudentsResponse> GetStudentsAsync(StudentsRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<StudentsRequest, StudentsResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<ClassesResponse> GetClassesAsync(ClassesRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<ClassesRequest, ClassesResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<SubjectsResponse> GetSubjectsAsync(SubjectsRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<SubjectsRequest, SubjectsResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<RoomsResponse> GetRoomsAsync(RoomsRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<RoomsRequest, RoomsResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<DepartmentsResponse> GetDepartmentsAsync(DepartmentsRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<DepartmentsRequest, DepartmentsResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<HolidaysResponse> GetHolidaysAsync(HolidaysRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<HolidaysRequest, HolidaysResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<TimegridResponse> GetTimegridAsync(TimegridRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<TimegridRequest, TimegridResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<StatusDataResponse> GetStatusDataAsync(StatusDataRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<StatusDataRequest, StatusDataResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<CurrentSchoolYearResponse> GetCurrentSchoolYearAsync(CurrentSchoolYearRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<CurrentSchoolYearRequest, CurrentSchoolYearResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<SchoolYearsResponse> GetSchoolYearsAsync(SchoolYearsRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<SchoolYearsRequest, SchoolYearsResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<TimetableResponse> GetTimetableAsync(SimpleTimetableRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<SimpleTimetableRequest, TimetableResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<ExamTypesResponse> GetExamTypesAsync(ExamTypesRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<ExamTypesRequest, ExamTypesResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<ExamsResponse> GetExamsAsync(ExamsRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<ExamsRequest, ExamsResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<ClassregEventsResponse> GetClassregEventsAsync(ClassregEventsRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<ClassregEventsRequest, ClassregEventsResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<SubstitutionsResponse> GetSubstitutionsAsync(SubstitutionsRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<SubstitutionsRequest, SubstitutionsResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<PersonIdResponse> GetPersonIdAsync(PersonIdRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<PersonIdRequest, PersonIdResponse>(_serviceUri, request, sessionId, token);
        }

        /// <inheritdoc cref="IRpcClient"/>
        public Task<LatestImportTimeResponse> GetLatestImportTimeAsync(LatestImportTimeRequest request, string sessionId, CancellationToken token = default(CancellationToken))
        {
            return SendAsync<LatestImportTimeRequest, LatestImportTimeResponse>(_serviceUri, request, sessionId, token);
        }
    }
}