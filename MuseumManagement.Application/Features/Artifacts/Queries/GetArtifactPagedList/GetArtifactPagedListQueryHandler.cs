using MediatR;
using MuseumManagement.Application.DTOs;
using MuseumManagement.Application.DTOs.Artifacts;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Application.Wrappers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Queries.GetArtifactPagedList
{
    public class GetArtifactPagedListQueryHandler(IArtifactRepository artifactRepository)
        : IRequestHandler<GetArtifactPagedListQuery, PagedResponse<ArtifactDto>>
    {
        public async Task<PagedResponse<ArtifactDto>> Handle(GetArtifactPagedListQuery request,
            CancellationToken cancellationToken)
        {
            var result = await artifactRepository
                .GetPagedListAsync(
                request.PageNumber,
                request.PageSize,
                request.SerialNumber
                );

            return new PagedResponse<ArtifactDto>(result, request);

        }
    }
}
