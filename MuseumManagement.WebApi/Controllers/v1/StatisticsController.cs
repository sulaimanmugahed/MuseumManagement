using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuseumManagement.Application.DTOs.Statistics;
using MuseumManagement.Application.Features.Statistics.Queries.GetArtifactStatisticsByBiodegradability;
using MuseumManagement.Application.Features.Statistics.Queries.GetArtifactStatisticsByCondition;
using MuseumManagement.Application.Features.Statistics.Queries.GetArtifactStatisticsByType;
using MuseumManagement.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuseumManagement.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class StatisticsController : BaseApiController
    {
        [HttpGet,Authorize]
        public async Task<BaseResult<List<ArtifactStatisticsByTypeDto>>> GetArtifactStatisticsByType()
            => await Mediator.Send(new GetArtifactStatisticsByTypeQuery());

        [HttpGet,Authorize]
        public async Task<BaseResult<List<ArtifactStatisticsByBiodegradabilityDto>>> GetArtifactStatisticsByBiodegradability()
            => await Mediator.Send(new GetArtifactStatisticsByBiodegradabilityQuery());

        [HttpGet,Authorize]
        public async Task<BaseResult<List<ArtifactStatisticsByConditionDto>>> GetArtifactStatisticsByCondition()
           => await Mediator.Send(new GetArtifactStatisticsByConditionQuery());

    }
}
