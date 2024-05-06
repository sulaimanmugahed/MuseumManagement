using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Safes.Commands.Common
{
    public interface ISafeCommand
    {
        public string Name { get; set; }    
        public string? StowageId { get; set; }
    }
}
