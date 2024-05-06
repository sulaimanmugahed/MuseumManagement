using MediatR;
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

namespace MuseumManagement.Application.Features.Artifacts.Commands.DeleteArtifact
{
    public class DeleteArtifactCommandHandler(IUnitOfWork unitOfWork,IArtifactRepository artifactRepository,ITranslator translator)
        : IRequestHandler<DeleteArtifactCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(DeleteArtifactCommand request, CancellationToken cancellationToken)
        {
            var artifact = await artifactRepository.GetByIdAsync(request.Id);
            if (artifact is null)
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.Id.Value)), nameof(request.Id)));

            artifact.Delete();
            await unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
