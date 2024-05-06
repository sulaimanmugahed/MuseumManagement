using MediatR;
using MuseumManagement.Application.Helpers;
using MuseumManagement.Application.Interfaces;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Application.Wrappers;
using MuseumManagement.Domain.Artifacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Commands.DeleteArtifactImage
{
    public class DeleteArtifactImageCommandHandler(
        IArtifactRepository artifactRepository,
        IFileManagerService fileManagerService,
        IUnitOfWork unitOfWork,
        ITranslator translator)
        : IRequestHandler<DeleteArtifactImageCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(DeleteArtifactImageCommand request, CancellationToken cancellationToken)
        {

            var artifact = await artifactRepository.GetArtifactDetailAsync(new ArtifactId(request.ArtifactId));
            if (artifact is null)
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.ArtifactId)), nameof(request.ArtifactId)));

            var artifactImage = artifact.ArtifactImages
                .FirstOrDefault(i => i.Url == request.ImageUrl);

            if (artifactImage is null)
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.ImageUrl)), nameof(request.ImageUrl)));

            var result = fileManagerService.Delete(request.ImageUrl);
            if (!result)
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.ImageUrl)), nameof(request.ImageUrl)));

            artifact.RemoveImage(artifactImage);
            await unitOfWork.SaveChangesAsync();
            return new BaseResult();
        }
    }
}
