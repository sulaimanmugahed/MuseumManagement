using MuseumManagement.Application.DTOs.Account.Requests;
using MuseumManagement.Application.DTOs.Account.Responses;
using MuseumManagement.Application.Wrappers;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Interfaces.UserInterfaces
{
    public interface IGetUserServices
    {
        Task<PagedResponse<UserDto>> GetPagedUsers(GetAllUsersRequest model);
    }
}
