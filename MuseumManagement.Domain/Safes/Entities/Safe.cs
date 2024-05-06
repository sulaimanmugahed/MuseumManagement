using MuseumManagement.Domain.Artifacts.Entities;
using MuseumManagement.Domain.Common;
using MuseumManagement.Domain.Stowages;
using MuseumManagement.Domain.Stowages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Domain.Safes.Entities
{
    public class Safe
    {
        private readonly List<Artifact> _artifacts = [];

        private Safe()
        {

        }

        public IReadOnlyCollection<Artifact> Artifacts =>
           _artifacts;

        public Safe(SafeId id, string name)
        {
            Id = id;
            Name = name;
        }

        public SafeId Id { get; private set; }
        public string Name { get; private set; }
        public StowageId? StowageId { get; private set; }
        public Stowage Stowage {  get; private set; }

        public void SetStowage(StowageId stowageId)
        {
            StowageId = stowageId;
        }

        public void AddArtifact(Artifact artifact)
        {
            artifact.SetSafe(Id);
            _artifacts.Add(artifact);
        }
    }
}
