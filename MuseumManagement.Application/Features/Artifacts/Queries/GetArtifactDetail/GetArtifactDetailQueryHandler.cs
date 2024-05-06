using MediatR;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Application.Interfaces;
using MuseumManagement.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;
using MuseumManagement.Application.Helpers;

using MuseumManagement.Domain.Artifacts;
using MuseumManagement.Application.DTOs.Artifacts;


namespace MuseumManagement.Application.Features.Artifacts.Queries.GetArtifactDetail
{
    public class GetArtifactDetailQueryHandler(IArtifactRepository artifactRepository, ITranslator translator) : IRequestHandler<GetArtifactDetailQuery, BaseResult<ArtifactDetailDto>>
    {
        public async Task<BaseResult<ArtifactDetailDto>> Handle(GetArtifactDetailQuery request, CancellationToken cancellationToken)
        {
            var artifact = await artifactRepository
                .GetArtifactDetailAsync(new ArtifactId(request.Id));

           
            if (artifact is null)
                return new BaseResult<ArtifactDetailDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.Id)), nameof(request.Id)));


            return new BaseResult<ArtifactDetailDto>(new ArtifactDetailDto(artifact));
        }
    }
}
