using MediatR;
using MuseumManagement.Application.Helpers;
using MuseumManagement.Application.Interfaces;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Application.Wrappers;
using MuseumManagement.Domain.Artifacts;
using MuseumManagement.Domain.Safes;
using MuseumManagement.Domain.Safes.Entities;
using MuseumManagement.Domain.Stowages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Safes.Commands.CreateSafe
{
    public class CreateSafeCommandHandler(
        ISafeRepository safeRepository,
        IStowageRepository stowageRepository,
        ITranslator translator,
        IUnitOfWork unitOfWork) 
        : IRequestHandler<CreateSafeCommand, BaseResult<string>>
    {
        public async Task<BaseResult<string>> Handle(CreateSafeCommand request, CancellationToken cancellationToken)
        {
            var safe = new Safe(
                new SafeId(Guid.NewGuid().ToString()),
                request.Name
                );

            if(request.StowageId is not null)
            {
                var stowage = await stowageRepository.GetByIdAsync(new StowageId(request.StowageId));
                if(stowage is null)
                    return new BaseResult<string>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.StowageId)), nameof(request.StowageId)));

                safe.SetStowage(stowage.Id);
            }

            await safeRepository.AddAsync(safe);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult<string>(safe.Id.Value);
        }
    }
}
