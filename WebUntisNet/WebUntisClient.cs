using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebUntisNet.Net;
using WebUntisNet.Rpc;
using WebUntisNet.Rpc.Types;
using WebUntisNet.Types;

namespace WebUntisNet
{
    public class WebUntisClient : IDisposable
    {
        private const string DefaultClientName = "WebUntisNet";
        private readonly IRpcClient _rpcClient;

        private string _sessionId;
        private bool _disposed = false; // To detect redundant calls

        /// <summary>
        /// Gets the person type of the user who's logged in.
        /// </summary>
        public PersonType? PersonType { get; private set; }

        /// <summary>
        /// Gets the person id of the user who's logged in.
        /// </summary>
        public int? PersonId { get; private set; }

        public WebUntisClient(string serviceEndpoint, string schoolName, string userName, string password) : this(serviceEndpoint, schoolName, userName, password, DefaultClientName)
        {
        }

        public WebUntisClient(string serviceEndpoint, string schoolName, string userName, string password, string clientName)
        {
            _rpcClient = new RpcClient(new HttpClient(), serviceEndpoint);

            AuthenticateAsync(schoolName, userName, password, clientName).GetAwaiter().GetResult();
        }

        public async Task AuthenticateAsync(string schoolName, string userName, string password, string clientName, CancellationToken token = default(CancellationToken))
        {
            var request = new AuthenticationRequest(userName, password, clientName);
            var result = await _rpcClient.AuthenticateAsync(schoolName, request);

            if (result.error?.code != null)
            {
                throw new RpcException(result.error.code, result.error.message);
            }

            _sessionId = result.result.sessionId;
            PersonType = (PersonType)result.result.personType;
            PersonId = result.result.personId;
        }

        /// <summary>
        /// Gets all classes for school year.
        /// </summary>
        /// <param name="schoolYearId">The school year id.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A list of classes.</returns>
        public async Task<List<Types.Class>> GetClassesAsync(int schoolYearId, CancellationToken token = default(CancellationToken))
        {
            EnsureLoggedIn();

            var rpcRequest = new ClassesRequest(schoolYearId.ToString());
            var rpcResult = await _rpcClient.GetClassesAsync(rpcRequest, _sessionId, token);

            if (rpcResult.error?.code != null)
            {
                throw new RpcException(rpcResult.error.code, rpcResult.error.message);
            }

            var result = rpcResult.result.Select(x => new Types.Class
                {
                    Id = x.id,
                    Name = x.name,
                    LongName = x.longName,
                    BackColorHex = x.backColor,
                    ForeColorHex = x.foreColor
                })
                .ToList();
            return result;
        }

        /// <summary>
        /// Ends the current session.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task LogoutAsync(CancellationToken token = default(CancellationToken))
        {
            if (IsLoggedIn)
            {
                var request = new LogoutRequest();
                var result = await _rpcClient.LogoutAsync(request, _sessionId);

                if (!string.IsNullOrEmpty(result?.error?.message))
                {
                    throw new RpcException(result.error.message);
                }
            }

            _sessionId = null;
            PersonType = null;
            PersonId = null;
        }

        /// <summary>
        /// Gets all exams for an exam type within the specified time range.
        /// </summary>
        /// <param name="examTypeId">The exam type id.</param>
        /// <param name="startDate">The start date (only date part is relevant).</param>
        /// <param name="endDate">The end date (only date part is relevant).</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A list of exams.</returns>
        public async Task<List<Types.Exam>> GetExamsAsync(int examTypeId, DateTime startDate, DateTime endDate, CancellationToken token = default(CancellationToken))
        {
            EnsureLoggedIn();

            var rpcRequest = new ExamsRequest(examTypeId, startDate.ToApiDate(), endDate.ToApiDate());
            var rpcResult = await _rpcClient.GetExamsAsync(rpcRequest, _sessionId, token);

            if (rpcResult.error?.code != null)
            {
                throw new RpcException(rpcResult.error.code, rpcResult.error.message);
            }

            var result = rpcResult.result.Select(x => new Types.Exam
            {
                Id = x.id,
                ClassesIds = x.classes,
                StudentIds = x.students,
                SubjectId = x.subject,
                TeacherIds = x.teachers,
                StartTime = TypeConverter.ApiDateAndTimeToDateTime(x.date, x.startTime),
                EndTime = TypeConverter.ApiDateAndTimeToDateTime(x.date, x.endTime)
            })
            .ToList();
            return result;
        }

        /// <summary>
        /// Gets a list of all teachers.
        /// </summary>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A list of teachers.</returns>
        public async Task<List<Types.Teacher>> GetTeachersAsync(CancellationToken token = default(CancellationToken))
        {
            EnsureLoggedIn();

            var rpcRequest = new TeachersRequest();
            var rpcResult = await _rpcClient.GetTeachersAsync(rpcRequest, _sessionId, token);

            if (rpcResult.error?.code != null)
            {
                throw new RpcException(rpcResult.error.code, rpcResult.error.message);
            }

            var result = rpcResult.result.Select(x => new Types.Teacher
                {
                    Id = x.id,
                    Abbreviation = x.name,
                    BackColor = x.backColor,
                    FirstName = x.foreName,
                    LastName = x.longName,
                    ForeColor = x.foreColor
                })
                .ToList();
            return result;
        }

        /// <summary>
        /// Gets a list of all students.
        /// </summary>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A list of students.</returns>
        public async Task<List<Types.Student>> GetStudentsAsync(CancellationToken token = default(CancellationToken))
        {
            EnsureLoggedIn();

            var rpcRequest = new StudentsRequest();
            var rpcResult = await _rpcClient.GetStudentsAsync(rpcRequest, _sessionId, token);

            if (rpcResult.error?.code != null)
            {
                throw new RpcException(rpcResult.error.code, rpcResult.error.message);
            }

            var result = rpcResult.result.Select(x => new Types.Student
                {
                    Id = x.id,
                    Key = x.key,
                    Abbreviation = x.name,
                    FirstName = x.foreName,
                    LastName = x.longName,
                    Gender = "male".Equals(x.gender) ? Gender.Male : Gender.Female
                })
                .ToList();
            return result;
        }


        /// <summary>
        /// Gets a list of all rooms.
        /// </summary>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A list of rooms.</returns>
        public async Task<List<Types.Room>> GetRoomsAsync(CancellationToken token = default(CancellationToken))
        {
            EnsureLoggedIn();

            var rpcRequest = new RoomsRequest();
            var rpcResult = await _rpcClient.GetRoomsAsync(rpcRequest, _sessionId, token);

            if (rpcResult.error?.code != null)
            {
                throw new RpcException(rpcResult.error.code, rpcResult.error.message);
            }

            var result = rpcResult.result.Select(x => new Types.Room
                {
                    Id = x.id,
                    LongName = x.longName,
                    ForeColorHex = x.foreColor,
                    BackColorHex = x.backColor,
                    Name = x.name
                })
                .ToList();
            return result;
        }


        /// <summary>
        /// Gets a list of all holidays.
        /// </summary>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A list of holidays.</returns>
        public async Task<List<Types.Holiday>> GetHolidaysAsync(CancellationToken token = default(CancellationToken))
        {
            EnsureLoggedIn();

            var rpcRequest = new HolidaysRequest();
            var rpcResult = await _rpcClient.GetHolidaysAsync(rpcRequest, _sessionId, token);

            if (rpcResult.error?.code != null)
            {
                throw new RpcException(rpcResult.error.code, rpcResult.error.message);
            }

            var result = rpcResult.result.Select(x => new Types.Holiday
                {
                    Id = x.id,
                    LongName = x.longName,
                    Name = x.name,
                    StartDate = TypeConverter.ApiDateToDateTime(x.startDate),
                    EndDate = TypeConverter.ApiDateToDateTime(x.endDate)
                })
                .ToList();
            return result;
        }

        /// <summary>
        /// Gets a list of all departments.
        /// </summary>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A list of departments.</returns>
        public async Task<List<Types.Department>> GetDepartmentsAsync(CancellationToken token = default(CancellationToken))
        {
            EnsureLoggedIn();

            var rpcRequest = new DepartmentsRequest();
            var rpcResult = await _rpcClient.GetDepartmentsAsync(rpcRequest, _sessionId, token);

            if (rpcResult.error?.code != null)
            {
                throw new RpcException(rpcResult.error.code, rpcResult.error.message);
            }

            var result = rpcResult.result.Select(x => new Types.Department
                {
                    Id = x.id,
                    LongName = x.longName,
                    Name = x.name
                })
                .ToList();
            return result;
        }

        // TODO: GetSubjectsAsync
        // TODO: GetTimegridAsync
        // TODO: GetStatusDataAsync
        // TODO: GetCurrentSchoolYearAsync
        // TODO: GetSchoolYearsAsync
        // TODO: GetTimetableAsync

        // TODO: Request timetable for an element (customizable)

        // TODO: GetLatestImportTimeAsync
        // TODO: GetPersonIdAsync
        // TODO: GetSubstitutionsAsync
        // TODO: GetClassregEventsAsync
        // TODO: GetExamTypesAsync


        private void EnsureLoggedIn()
        {
            if (IsLoggedIn)
            {
                return;
            }

            throw new NotAutenticatedException();
        }

        /// <summary>
        /// Returns whether the user is currently logged in (session exists) or not.
        /// </summary>
        public bool IsLoggedIn => !string.IsNullOrEmpty(_sessionId);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (IsLoggedIn)
                    {
                        LogoutAsync().GetAwaiter().GetResult();
                    }
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
