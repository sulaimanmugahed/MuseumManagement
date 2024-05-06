using MuseumManagement.Domain.Artifacts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Commands.Common
{
    public interface IArtifactCommand
    {
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public string? OldMuseumNumber { get; set; }
        public string? NewMuseumNumber { get; set; }
        public int Count { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public string? Note { get; set; }
        public string? ImageLink { get; set; }
        public ArtifactType Type { get; set; }
        public ArtifactCondition Condition { get; set; }
        public Biodegradability Biodegradability { get; set; }
        public string? ImportantMaterialId { get; set; }
        public List<string>? MaterialIds { get; set; }
        public string? SafeId { get; set; }
        public string? TimePeriodId { get; set; }
    }
}
