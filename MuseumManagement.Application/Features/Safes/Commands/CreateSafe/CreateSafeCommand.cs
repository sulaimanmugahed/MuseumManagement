using MediatR;
using MuseumManagement.Application.Features.Safes.Commands.Common;
using MuseumManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Safes.Commands.CreateSafe
{
    public class CreateSafeCommand:IRequest<BaseResult<string>>,ISafeCommand
    {
        public string Name { get; set; } = string.Empty;
        public string? StowageId { get; set; }
    }
}
