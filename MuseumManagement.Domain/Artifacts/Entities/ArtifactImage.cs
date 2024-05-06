using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Domain.Artifacts.Entities
{
    public class ArtifactImage
    {
        private ArtifactImage()
        {
            
        }

        public ArtifactImage(ArtifactImageId id, string url, ArtifactId artifactId)
        {
            Id = id;
            Url = url;
            ArtifactId = artifactId;  
        }
        public ArtifactImageId Id { get;private set; }
        public string Url { get;private set; }
        public ArtifactId ArtifactId { get;private set; }
        public Artifact Artifact { get;private set; }

        internal void UpdateUrl(string url)
        {
            Url = url;
        }

    }
}
