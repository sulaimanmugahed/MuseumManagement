using MediatR;
using MuseumManagement.Application.DTOs.Statistics;
using MuseumManagement.Application.Features.Statistics.Queries.GetArtifactStatisticsByBiodegradability;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Statistics.Queries.GetArtifactStatisticsByCondition
{
    public class GetArtifactStatisticsByConditionQueryHandler(IArtifactRepository artifactRepository)
    : IRequestHandler<GetArtifactStatisticsByConditionQuery,
        BaseResult<List<ArtifactStatisticsByConditionDto>>>
    {
        public async Task<BaseResult<List<ArtifactStatisticsByConditionDto>>> Handle(GetArtifactStatisticsByConditionQuery request, CancellationToken cancellationToken)
        {
            var result = await artifactRepository.GetArtifactsCountGroupByCondition();

            return new BaseResult<List<ArtifactStatisticsByConditionDto>>(result);
        }
    }
}
