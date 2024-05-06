using MuseumManagement.Domain.Artifacts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.DTOs.Statistics
{
    public class ArtifactStatisticsByBiodegradabilityDto
    {
        public Biodegradability Biodegradability { get; set; }
        public int ArtifactsCount { get; set; }
    }
}
