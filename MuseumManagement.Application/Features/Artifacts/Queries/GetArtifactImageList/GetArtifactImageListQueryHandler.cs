using MediatR;
using MuseumManagement.Application.DTOs.Artifacts;
using MuseumManagement.Application.Helpers;
using MuseumManagement.Application.Interfaces;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Queries.GetArtifactImageList
{
    public class GetArtifactImageListQueryHandler(IArtifactRepository artifactRepository,ITranslator translator) : IRequestHandler<GetArtifactImageListQuery, BaseResult<List<ArtifactImageDto>>>
    {
        public async Task<BaseResult<List<ArtifactImageDto>>> Handle(GetArtifactImageListQuery request, CancellationToken cancellationToken)
        {
            var artifact = await artifactRepository.GetArtifactDetailAsync(request.ArtifactId);
            if (artifact is null)
                return new BaseResult<List<ArtifactImageDto>>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.ArtifactId.Value)), nameof(request.ArtifactId)));

            return new BaseResult<List<ArtifactImageDto>>(artifact.ArtifactImages
                .Select(ai => new ArtifactImageDto(ai)).ToList());
        }
    }
}
