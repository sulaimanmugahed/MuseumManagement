using MediatR;
using MuseumManagement.Application.Helpers;
using MuseumManagement.Application.Interfaces;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Application.Wrappers;
using MuseumManagement.Domain.Safes;
using MuseumManagement.Domain.Safes.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Safes.Queries.GetSafeById
{
    public class GetSafeByIdQueryHandler(ISafeRepository safeRepository, ITranslator translator) : IRequestHandler<GetSafeByIdQuery, BaseResult<SafeDto>>
    {
        public async Task<BaseResult<SafeDto>> Handle(GetSafeByIdQuery request, CancellationToken cancellationToken)
        {
            var safe = await safeRepository.GetByIdAsync(request.Id);

            if (safe is null)
            {
                return new BaseResult<SafeDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ArtifactMessages.Artifact_notfound_with_id(request.Id.Value)), nameof(request.Id)));
            }

            var result = new SafeDto(safe);

            return new BaseResult<SafeDto>(result);
        }
    }
}
