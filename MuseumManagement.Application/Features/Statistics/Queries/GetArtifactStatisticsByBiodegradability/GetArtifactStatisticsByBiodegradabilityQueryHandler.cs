using MediatR;
using MuseumManagement.Application.DTOs.Statistics;
using MuseumManagement.Application.Features.Statistics.Queries.GetArtifactStatisticsByType;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Statistics.Queries.GetArtifactStatisticsByBiodegradability
{
    public class GetArtifactStatisticsByBiodegradabilityQueryHandler(IArtifactRepository artifactRepository)
    : IRequestHandler<GetArtifactStatisticsByBiodegradabilityQuery,
        BaseResult<List<ArtifactStatisticsByBiodegradabilityDto>>>
    {
        public async Task<BaseResult<List<ArtifactStatisticsByBiodegradabilityDto>>> Handle(GetArtifactStatisticsByBiodegradabilityQuery request, CancellationToken cancellationToken)
        {
            var result = await artifactRepository.GetArtifactsCountGroupByBiodegradability();

            return new BaseResult<List<ArtifactStatisticsByBiodegradabilityDto>>(result);
        }
    }
}
