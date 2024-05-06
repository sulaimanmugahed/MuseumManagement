using MuseumManagement.Application.DTOs.Account.Requests;
using MuseumManagement.Application.DTOs.Account.Responses;
using MuseumManagement.Application.Wrappers;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Interfaces.UserInterfaces
{
    public interface IAccountServices
    {
        Task<BaseResult<string>> RegisterGostAccount();
        Task<BaseResult> ChangePassword(ChangePasswordRequest model);
        Task<BaseResult> ChangeUserName(ChangeUserNameRequest model);
        Task<BaseResult<AuthenticationResponse>> Authenticate(AuthenticationRequest request);
        Task<BaseResult<AuthenticationResponse>> AuthenticateByUserName(string username);

    }
}
