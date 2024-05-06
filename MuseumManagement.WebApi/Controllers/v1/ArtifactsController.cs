
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MuseumManagement.Application.DTOs.Artifacts;
using MuseumManagement.Application.Features.Artifacts.Commands.AddArtifactImage;
using MuseumManagement.Application.Features.Artifacts.Commands.CreateArtifact;
using MuseumManagement.Application.Features.Artifacts.Commands.DeleteArtifact;
using MuseumManagement.Application.Features.Artifacts.Commands.DeleteArtifactImage;
using MuseumManagement.Application.Features.Artifacts.Commands.UpdateArtifact;
using MuseumManagement.Application.Features.Artifacts.Commands.UpdateArtifactImage;
using MuseumManagement.Application.Features.Artifacts.Queries.GetArtifactDetail;
using MuseumManagement.Application.Features.Artifacts.Queries.GetArtifactImageList;
using MuseumManagement.Application.Features.Artifacts.Queries.GetArtifactList;
using MuseumManagement.Application.Features.Artifacts.Queries.GetArtifactPagedList;
using MuseumManagement.Application.Wrappers;
using MuseumManagement.Domain.Artifacts;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MuseumManagement.WebApi.Controllers.v1
{

    [ApiVersion("1")]
    public class ArtifactsController : BaseApiController
    {

        [HttpGet, Authorize]
        public async Task<BaseResult<ArtifactDetailDto>> GetArtifactDetail([FromQuery] GetArtifactDetailQuery model)
           => await Mediator.Send(model);

        [HttpGet, Authorize]
        public async Task<BaseResult<List<ArtifactDto>>> GetArtifactList()
           => await Mediator.Send(new GetArtifactListQuery());
        
        [HttpGet, Authorize]
        public async Task<PagedResponse<ArtifactDto>> GetArtifactPagedList([FromQuery] GetArtifactPagedListQuery model)
           => await Mediator.Send(model);

        [HttpPost, Authorize]
        public async Task<BaseResult<ArtifactId>> CreateArtifact(CreateArtifactCommand model)
            => await Mediator.Send(model);

        [HttpPut, Authorize]
        public async Task<BaseResult> UpdateArtifact(UpdateArtifactCommand model)
          => await Mediator.Send(model);

        [HttpDelete, Authorize]
        public async Task<BaseResult> DeleteArtifact([FromQuery] DeleteArtifactCommand model)
            => await Mediator.Send(model);

        [HttpGet, Authorize]
        public async Task<BaseResult<List<ArtifactImageDto>>> GetArtifactImageList([FromQuery] GetArtifactImageListQuery model)
            => await Mediator.Send(model);

        [HttpPost, Authorize]
        public async Task<BaseResult> AddArtifactImages(AddArtifactImagesCommand model)
          => await Mediator.Send(model);

        [HttpPut,Authorize]
        public async Task<BaseResult> UpdateArtifactImage(UpdateArtifactImageCommand model)
           => await Mediator.Send(model);

        [HttpDelete, Authorize]
        public async Task<BaseResult> DeleteArtifactImage([FromQuery] DeleteArtifactImageCommand model)
            => await Mediator.Send(model);


    }
}
