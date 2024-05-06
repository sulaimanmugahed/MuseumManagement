using MediatR;
using Microsoft.AspNetCore.Http;
using MuseumManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Commands.AddArtifactImage
{
    public class AddArtifactImagesCommand:IRequest<BaseResult>
    {
        public string ArtifactId { get; set; }
        public IFormFileCollection ArtifactImages { get; set; }
    }
}
