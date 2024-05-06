using MediatR;
using MuseumManagement.Application.DTOs.Artifacts;
using MuseumManagement.Application.Wrappers;
using MuseumManagement.Domain.Artifacts;
using MuseumManagement.Domain.Artifacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Queries.GetArtifactImageList
{
    public class GetArtifactImageListQuery:IRequest<BaseResult<List<ArtifactImageDto>>>
    {
       public ArtifactId ArtifactId { get; set; }
    }
}
