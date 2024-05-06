using MediatR;
using MuseumManagement.Application.DTOs.Statistics;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Statistics.Queries.GetArtifactStatisticsByType
{
    public class GetArtifactStatisticsByTypeQueryHandler(IArtifactRepository artifactRepository) : IRequestHandler<GetArtifactStatisticsByTypeQuery, BaseResult<List<ArtifactStatisticsByTypeDto>>>
    {
        public async Task<BaseResult<List<ArtifactStatisticsByTypeDto>>> Handle(GetArtifactStatisticsByTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await artifactRepository.GetArtifactsCountGroupByType();

            return new BaseResult<List<ArtifactStatisticsByTypeDto>>(result);
        }
    }
}
