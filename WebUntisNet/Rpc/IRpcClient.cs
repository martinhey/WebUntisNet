using System.Threading;
using System.Threading.Tasks;
using WebUntisNet.Rpc.Types;

namespace WebUntisNet.Rpc
{
    public interface IRpcClient
    {
        /// <summary>
        /// Authenticate the given user and start a session.
        /// </summary>
        /// <param name="schoolName">The name of the school.</param>
        /// <param name="request">The request parameters.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<AuthenticationResponse> AuthenticateAsync(string schoolName, AuthenticationRequest request, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// End the session.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<EmptyResponse> LogoutAsync(LogoutRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get list of teachers.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<TeachersResponse> GetTeachersAsync(TeachersRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get list of students.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<StudentsResponse> GetStudentsAsync(StudentsRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get list of base classes for schoolyear.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<ClassesResponse> GetClassesAsync(ClassesRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get list of subjects.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<SubjectsResponse> GetSubjectsAsync(SubjectsRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get list of rooms.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<RoomsResponse> GetRoomsAsync(RoomsRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get list of departments.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<DepartmentsResponse> GetDepartmentsAsync(DepartmentsRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get list of holidays.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<HolidaysResponse> GetHolidaysAsync(HolidaysRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get timegrid.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<TimegridResponse> GetTimegridAsync(TimegridRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get information about lesson types and period codes and their colors.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<StatusDataResponse> GetStatusDataAsync(StatusDataRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get data for the current schoolyear
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<SchoolYearsResponse> GetCurrentSchoolYearAsync(CurrentSchoolYearRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// List of all available schoolyears.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<SchoolYearsResponse> GetSchoolYearsAsync(SchoolYearsRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get timetable for class, teacher, student, room, subject.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<TimetableResponse> GetTimetableAsync(SimpleTimetableRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        // TODO: Request timetable for an element (customizable)

        /// <summary>
        /// Import time of the last lesson/timetable or substitution import from Untis
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<LatestImportTimeResponse> GetLatestImportTimeAsync(LatestImportTimeRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get Id of the person (teacher or student) from the name.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<PersonIdResponse> GetPersonIdAsync(PersonIdRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Request substitutions for the given date range.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<SubstitutionsResponse> GetSubstitutionsAsync(SubstitutionsRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Request classregevents for the given date range.
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<ClassregEventsResponse> GetClassregEventsAsync(ClassregEventsRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Request Exams
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<ExamsResponse> GetExamsAsync(ExamsRequest request, string sessionId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Request ExamTypes
        /// </summary>
        /// <param name="request">The request parameters.</param>
        /// <param name="sessionId">The session id returned by <see cref="AuthenticateAsync"/>.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The rpc response.</returns>
        Task<ExamTypesResponse> GetExamTypesAsync(ExamTypesRequest request, string sessionId, CancellationToken token = default(CancellationToken));
    }

}