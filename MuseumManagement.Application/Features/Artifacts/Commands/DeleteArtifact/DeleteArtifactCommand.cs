using MediatR;
using MuseumManagement.Application.Wrappers;
using MuseumManagement.Domain.Artifacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Commands.DeleteArtifact
{
    public class DeleteArtifactCommand:IRequest<BaseResult>
    {
        public ArtifactId Id { get; set; }
    }
}
