using MediatR;
using MuseumManagement.Application.DTOs.Artifacts;
using MuseumManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Queries.GetArtifactList
{
    public class GetArtifactListQuery :IRequest<BaseResult<List<ArtifactDto>>>
    {
        
    }
}
