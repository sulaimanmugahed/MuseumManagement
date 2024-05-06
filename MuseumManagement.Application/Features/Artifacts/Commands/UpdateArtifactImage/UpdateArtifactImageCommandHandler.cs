using MediatR;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Application.Interfaces;
using MuseumManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MuseumManagement.Application.Helpers;
using MuseumManagement.Domain.Artifacts;
using static MuseumManagement.Application.Helpers.TranslatorMessages;

namespace MuseumManagement.Application.Features.Artifacts.Commands.UpdateArtifactImage
{
    public class UpdateArtifactImageCommandHandler(
        IArtifactRepository artifactRepository,
        IFileManagerService fileManagerService,
        IUnitOfWork unitOfWork,
        ITranslator translator)
        : IRequestHandler<UpdateArtifactImageCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(UpdateArtifactImageCommand request, CancellationToken cancellationToken)
        {
            var artifact = await artifactRepository.GetArtifactDetailAsync(new ArtifactId(request.ArtifactId));
            if (artifact is null)
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.ArtifactId)), nameof(request.ArtifactId)));

            var artifactImage = artifact.ArtifactImages
                .FirstOrDefault(i => i.Url == request.ImageUrl);

            if (artifactImage is null)
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.ImageUrl)), nameof(request.ImageUrl)));

            var deleteResult = fileManagerService.Delete(request.ImageUrl);
            if (!deleteResult)
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.ImageUrl)), nameof(request.ImageUrl)));

            var imageUrl = await fileManagerService.Upload(request.ArtifactImage, artifact.Id.Value, "ArtifactImages");
            if (imageUrl is null)
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.ImageUrl)), nameof(request.ImageUrl)));

            artifact.UpdateImage(artifactImage,imageUrl);

            await unitOfWork.SaveChangesAsync();
            return new BaseResult();
        }
    }
}
