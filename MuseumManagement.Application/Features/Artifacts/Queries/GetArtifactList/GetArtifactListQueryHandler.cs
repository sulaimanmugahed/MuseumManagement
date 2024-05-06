using MediatR;
using MuseumManagement.Application.DTOs.Artifacts;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Application.Wrappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Queries.GetArtifactList
{
    public class GetArtifactListQueryHandler(IArtifactRepository artifactRepository)
        : IRequestHandler<GetArtifactListQuery, BaseResult<List<ArtifactDto>>>
    {
        public async Task<BaseResult<List<ArtifactDto>>> Handle(GetArtifactListQuery request,
            CancellationToken cancellationToken)
        {
            var artifacts = await artifactRepository.GetAllAsync();
            return new BaseResult<List<ArtifactDto>>(artifacts.Select(a =>
            new ArtifactDto(a)).ToList());
        }
    }
}
