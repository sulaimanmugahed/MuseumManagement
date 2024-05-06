using MediatR;
using MuseumManagement.Application.DTOs.Artifacts;
using MuseumManagement.Application.Wrappers;
using MuseumManagement.Domain.Artifacts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Queries.GetArtifactDetail
{
    public class GetArtifactDetailQuery : IRequest<BaseResult<ArtifactDetailDto>>
    {
        public string Id { get; set; }

        //[JsonIgnore]
        //public ArtifactId ArtifactId
        //    => new(Id);
    }
}
