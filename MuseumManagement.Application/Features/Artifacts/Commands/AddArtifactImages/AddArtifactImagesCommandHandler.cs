using MediatR;
using MuseumManagement.Application.Features.Artifacts.Commands.AddArtifactImage;
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
using MuseumManagement.Domain.Artifacts.Entities;
using MuseumManagement.Domain.Artifacts;

namespace MuseumManagement.Application.Features.Artifacts.Commands.AddArtifactImages
{
    public class AddArtifactImagesCommandHandler(
        IArtifactRepository artifactRepository,
        IFileManagerService fileManagerService,
        IUnitOfWork unitOfWork,
        ITranslator translator)
        : IRequestHandler<AddArtifactImagesCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(AddArtifactImagesCommand request, CancellationToken cancellationToken)
        {
            var artifact = await artifactRepository.GetByIdAsync(new ArtifactId(request.ArtifactId));
            if(artifact is null)
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.ArtifactId)), nameof(request.ArtifactId)));

            foreach (var image in request.ArtifactImages)
            {
                var imageUrl = await fileManagerService
                    .Upload(image, artifact.Id.Value, "ArtifactImages");

                if (imageUrl is null)
                    return new BaseResult<ArtifactId>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.ArtifactId)), nameof(request.ArtifactImages)));

                artifact.AddImage(imageUrl);
            }

            await unitOfWork.SaveChangesAsync();
            return new BaseResult();
        }
    }
}
