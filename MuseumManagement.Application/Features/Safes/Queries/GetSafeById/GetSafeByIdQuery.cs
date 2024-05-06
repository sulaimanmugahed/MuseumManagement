using MediatR;
using MuseumManagement.Application.Wrappers;
using MuseumManagement.Domain.Safes;
using MuseumManagement.Domain.Safes.Dtos;

namespace MuseumManagement.Application.Features.Safes.Queries.GetSafeById
{
    public class GetSafeByIdQuery : IRequest<BaseResult<SafeDto>>
    {
        public SafeId Id { get; set; }
    }
}
