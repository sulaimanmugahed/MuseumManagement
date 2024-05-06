
using Microsoft.AspNetCore.Http;
using MuseumManagement.Domain.Artifacts.Entities;
using MuseumManagement.Domain.Artifacts.Enums;

namespace MuseumManagement.Application.DTOs.Artifacts
{
    public class ArtifactDto
    {
        public ArtifactDto()
        {

        }

        public ArtifactDto(Artifact artifact)
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

    }
}
