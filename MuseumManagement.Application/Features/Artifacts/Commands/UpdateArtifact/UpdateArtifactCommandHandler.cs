using MediatR;
using MuseumManagement.Application.Helpers;
using MuseumManagement.Application.Interfaces;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Application.Wrappers;
using MuseumManagement.Domain.Artifacts;
using MuseumManagement.Domain.Artifacts.Entities;
using MuseumManagement.Domain.Materials;
using MuseumManagement.Domain.Materials.Entities;
using MuseumManagement.Domain.Safes;
using MuseumManagement.Domain.TimePeriods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Commands.UpdateArtifact
{
    public class UpdateArtifactCommandHandler(
        IArtifactRepository artifactRepository,
        ITimePeriodRepository timePeriodRepository,
        ISafeRepository safeRepository,
        IMaterialRepository materialRepository,
        IUnitOfWork unitOfWork,
        ITranslator translator,
        IFileManagerService fileManagerService)
        : IRequestHandler<UpdateArtifactCommand, BaseResult>
    {

        public async Task<BaseResult> Handle(UpdateArtifactCommand request,
            CancellationToken cancellationToken)
        {
            var artifact = await artifactRepository.GetArtifactDetailAsync(new ArtifactId(request.Id));
            if (artifact is null)
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.Id)), nameof(request.Id)));

            artifact.Update(
            request.Name,
            request.SerialNumber,
            request.OldMuseumNumber,
            request.NewMuseumNumber,
            request.Count,
            request.Description,
            request.Size,
            request.Note,
            request.ImageLink,
            request.Type,
            request.Condition,
            request.Biodegradability
            );


            if (request.MaterialIds?.Count > 0)
            {
                List<MaterialId> materialIds = request.MaterialIds
                .Select(id => new MaterialId(id)).ToList();

                var importantMaterialId = materialIds
                    .FirstOrDefault(m => m.Value == request.ImportantMaterialId);

                foreach (var materialId in materialIds)
                {
                    var material = await materialRepository.GetByIdAsync(materialId);
                    if (material is null)
                        return new BaseResult<ArtifactId>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(materialId.Value)), nameof(request.MaterialIds)));
                }

                artifact.UpdateMaterials(materialIds, importantMaterialId);
            }


            if (!string.IsNullOrEmpty(request.SafeId))
            {
                var safe = await safeRepository.GetByIdAsync(new SafeId(request.SafeId));
                if (safe is null)
                    return new BaseResult<ArtifactId>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.SafeId)), nameof(request.SafeId)));

                artifact.SetSafe(new SafeId(request.SafeId));
            }


            if (!string.IsNullOrEmpty(request.TimePeriodId))
            {
                var timePeriod = await timePeriodRepository.GetByIdAsync(new TimePeriodId(request.TimePeriodId));
                if (timePeriod is null)
                    return new BaseResult<ArtifactId>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.TimePeriodId)), nameof(request.TimePeriodId)));

                artifact.SetTimePeriod(new TimePeriodId(request.TimePeriodId));
            }

            if (request.ArtifactImages?.Count > 0)
            {
                foreach (var image in request.ArtifactImages)
                {
                    var imageUrl = await fileManagerService
                        .Upload(image, artifact.Id.Value, "ArtifactImages");

                    if (imageUrl is null)
                        return new BaseResult<ArtifactId>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.TimePeriodId)), nameof(request.TimePeriodId)));

                    artifact.AddImage(imageUrl);
                }
            }

            await unitOfWork.SaveChangesAsync();
            return new BaseResult();
        }
    }
}
