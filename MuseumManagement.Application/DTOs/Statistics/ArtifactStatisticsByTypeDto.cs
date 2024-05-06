using MuseumManagement.Domain.Artifacts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.DTOs.Statistics
{
    public class ArtifactStatisticsByTypeDto
    {
        public ArtifactType Type { get; set; }
        public int ArtifactsCount { get; set; }
    }
}
