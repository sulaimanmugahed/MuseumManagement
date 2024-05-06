
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuseumManagement.Application.Features.Safes.Commands.CreateSafe;
using MuseumManagement.Application.Features.Safes.Queries.GetSafeById;
using MuseumManagement.Application.Wrappers;
using MuseumManagement.Domain.Safes.Dtos;
using System.Threading.Tasks;

namespace MuseumManagement.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class SafesController : BaseApiController
    {

        [HttpGet, Authorize(Roles ="SuperAdmin")]
        public async Task<BaseResult<SafeDto>> GetSafeById([FromQuery] GetSafeByIdQuery model)
            => await Mediator.Send(model);

        [HttpPost, Authorize(Roles = "SuperAdmin")]
        public async Task<BaseResult<string>> CreateSafe(CreateSafeCommand model)
            => await Mediator.Send(model);




    }
}