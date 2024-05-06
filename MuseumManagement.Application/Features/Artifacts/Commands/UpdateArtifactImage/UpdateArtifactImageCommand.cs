using MediatR;
using Microsoft.AspNetCore.Http;
using MuseumManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Commands.UpdateArtifactImage
{
    public class UpdateArtifactImageCommand:IRequest<BaseResult>
    {
        public string ArtifactId { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile ArtifactImage { get; set; }
    }
}
