using System.Threading.Tasks;
using WebUntisNet.Rpc.Types;

namespace WebUntisNet.Rpc
{
    public interface IRpcClient
    {
        Task<AuthenticationResponse> AuthenticateAsync(string schoolName, AuthenticationRequest request);
        Task<EmptyResponse> LogoutAsync(LogoutRequest request, string sessionId);
        Task<TeachersResponse> GetTeachersAsync(TeachersRequest request, string sessionId);
        Task<StudentsResponse> GetStudentsAsync(StudentsRequest request, string sessionId);
    }

}