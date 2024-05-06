using Microsoft.EntityFrameworkCore;
using MuseumManagement.Application.DTOs;
using MuseumManagement.Application.DTOs.Account.Requests;
using MuseumManagement.Application.DTOs.Account.Responses;
using MuseumManagement.Application.Interfaces;
using MuseumManagement.Application.Interfaces.UserInterfaces;
using MuseumManagement.Application.Wrappers;
using MuseumManagement.Infrastructure.Identity.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagement.Infrastructure.Identity.Services
{
    public class GetUserServices(IdentityContext identityContext) : IGetUserServices
    {
        public async Task<PagedResponse<UserDto>> GetPagedUsers(GetAllUsersRequest model)
        {
            var skip = (model.PageNumber - 1) * model.PageSize;

            var users = await identityContext.Users
                .Skip(skip)
                .Take(model.PageSize)
                .Select(p => new UserDto()
                {
                    Name = p.Name,
                    Email = p.Email,
                    UserName = p.UserName,
                    PhoneNumber = p.PhoneNumber,
                    Id = p.Id,
                    Created = p.Created,
                }).ToListAsync();

            var result = new PagenationResponseDto<UserDto>(users, await identityContext.Users.CountAsync());

            return new PagedResponse<UserDto>(result, model.PageNumber, model.PageSize);
        }
    }
}
