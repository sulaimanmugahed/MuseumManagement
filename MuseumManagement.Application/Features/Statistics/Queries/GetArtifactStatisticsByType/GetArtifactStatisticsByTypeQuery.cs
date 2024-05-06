using MediatR;
using MuseumManagement.Application.DTOs.Statistics;
using MuseumManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Statistics.Queries.GetArtifactStatisticsByType
{
    public class GetArtifactStatisticsByTypeQuery : IRequest<BaseResult<List<ArtifactStatisticsByTypeDto>>>
    {

    }
}
