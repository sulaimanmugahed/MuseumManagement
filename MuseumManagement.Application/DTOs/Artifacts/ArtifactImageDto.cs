using MuseumManagement.Domain.Artifacts;
using MuseumManagement.Domain.Artifacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.DTOs.Artifacts
{
    public class ArtifactImageDto
    {
        public ArtifactImageDto(ArtifactImage artifactImage)
        {
            Id = artifactImage.Id.Value;
            Url = artifactImage.Url;
            ArtifactId = artifactImage.ArtifactId.Value;
                

        }
        public string Id { get; set; }
        public string Url { get; set; }
        public string ArtifactId { get; set; }
    }
}
