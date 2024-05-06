using MuseumManagement.Domain.Artifacts.Entities;
using MuseumManagement.Domain.Artifacts.Enums;
using MuseumManagement.Domain.Materials.Dtos;
using MuseumManagement.Domain.Safes.Dtos;
using MuseumManagement.Domain.Safes.Entities;
using MuseumManagement.Domain.TimePeriods.Dtos;
using MuseumManagement.Domain.TimePeriods.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MuseumManagement.Application.DTOs.Artifacts
{
    public class ArtifactDetailDto
    {
        public ArtifactDetailDto()
        {

        }

        public ArtifactDetailDto(Artifact artifact)
        {
            Id = artifact.Id.Value;
            Name = artifact.Name;
            SerialNumber = artifact.SerialNumber;
            OldMuseumNumber = artifact.OldMuseumNumber;
            NewMuseumNumber = artifact.NewMuseumNumber;
            Count = artifact.Count;
            Description = artifact.Description;
            Size = artifact.Size;
            Note = artifact.Note;
            ImageLink = artifact.ImageLink;
            Type = artifact.Type;
            Condition = artifact.Condition;
            Biodegradability = artifact.Biodegradability;
            MapMaterials(artifact.ArtifactMaterials);
            MapSafe(artifact.Safe);
            MapTimePeriod(artifact.TimePeriod);
        }

    

        public string Id { get; set; }
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public string? OldMuseumNumber { get; set; }
        public string? NewMuseumNumber { get; set; }
        public int? Count { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public string? Note { get; set; }
        public string? ImageLink { get; set; }
        public ArtifactType Type { get; set; }
        public ArtifactCondition Condition { get; set; }
        public Biodegradability Biodegradability { get; set; }
        public List<MaterialDto>? Materials { get; set; } = [];
        public MaterialDto? ImportantMaterial { get; set; }
        public SafeDto? Safe { get; set; }
        public TimePeriodDto? TimePeriod { get; set; }

        private void MapSafe(Safe? safe)
        {
            if (safe is null)
                return;

            Safe = new SafeDto(safe);

        }

        private void MapTimePeriod(TimePeriod? timePeriod)
        {
            if (timePeriod is null)
                return;

            TimePeriod = new TimePeriodDto(timePeriod);
        }

        private void MapMaterials(IReadOnlyCollection<ArtifactMaterial> materials)
        {
            if (materials is null)
                return;
           
            Materials = materials
               .Select(am => new MaterialDto(am.Material))
               .ToList();

            var importantMaterial = materials
                .FirstOrDefault(am => am.IsImportantMaterial);

            if (importantMaterial is not null)
                ImportantMaterial = new MaterialDto(importantMaterial.Material);       
        }

    }
}
