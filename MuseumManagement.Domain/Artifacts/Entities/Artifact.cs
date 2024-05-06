using MuseumManagement.Domain.Artifacts.Enums;
using MuseumManagement.Domain.Common;
using MuseumManagement.Domain.Materials;
using MuseumManagement.Domain.Materials.Entities;
using MuseumManagement.Domain.Safes;
using MuseumManagement.Domain.Safes.Entities;
using MuseumManagement.Domain.TimePeriods;
using MuseumManagement.Domain.TimePeriods.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MuseumManagement.Domain.Artifacts.Entities
{
    public sealed class Artifact : AuditableBaseEntity
    {


        private Artifact() { }
        public Artifact(
        ArtifactId id,
        string name,
        int serialNumber,
        string? oldMuseumNumber,
        string? newMuseumNumber,
        int? count,
        string? description,
        string? size,
        string? note,
        string? imageLink,
        ArtifactType type,
        ArtifactCondition condition,
        Biodegradability biodegradability)

        {
            Id = id;
            Name = name;
            SerialNumber = serialNumber;
            OldMuseumNumber = oldMuseumNumber;
            NewMuseumNumber = newMuseumNumber;
            Count = count;
            Description = description;
            Size = size;
            Note = note;
            ImageLink = imageLink;
            Type = type;
            Condition = condition;
            Biodegradability = biodegradability;
        }

        private readonly List<ArtifactMaterial> _artifactMaterials = [];
        private readonly List<ArtifactImage> _artifactImages = [];
        public ArtifactId Id { get; private set; }
        public string Name { get; private set; }
        public int SerialNumber { get; private set; }
        public string? OldMuseumNumber { get; private set; }
        public string? NewMuseumNumber { get; private set; }
        public int? Count { get; private set; }
        public string? Description { get; private set; }
        public string? Size { get; private set; }
        public string? Note { get; private set; }
        public string? ImageLink { get; private set; }
        public ArtifactType Type { get; private set; }
        public ArtifactCondition Condition { get; private set; }
        public Biodegradability Biodegradability { get; private set; }
        public bool IsDeleted { get; private set; }

        public IReadOnlyCollection<ArtifactMaterial> ArtifactMaterials =>
            _artifactMaterials;

        public IReadOnlyCollection<ArtifactImage> ArtifactImages =>
            _artifactImages;

        public SafeId? SafeId { get; private set; }
        public Safe Safe { get; private set; }

        public TimePeriodId? TimePeriodId { get; private set; }
        public TimePeriod TimePeriod { get; private set; }

        public void Update(
        string name,
        int serialNumber,
        string? oldMuseumNumber,
        string? newMuseumNumber,
        int? count,
        string? description,
        string? size,
        string? note,
        string? imageLink,
        ArtifactType type,
        ArtifactCondition condition,
        Biodegradability biodegradability)
        {
            Name = name;
            SerialNumber = serialNumber;
            OldMuseumNumber = oldMuseumNumber;
            NewMuseumNumber = newMuseumNumber;
            Count = count;
            Description = description;
            Size = size;
            Note = note;
            ImageLink = imageLink;
            Type = type;
            Condition = condition;
            Biodegradability = biodegradability;
        }
        public void Delete()
        {
            if (IsDeleted)
                return;

            IsDeleted = true;
        }

        public void AddImage(string url)
        {
            var image = new ArtifactImage(
                new ArtifactImageId(Guid.NewGuid().ToString()),
                url,
                Id);
            _artifactImages.Add(image);
        }

        public void UpdateImage(ArtifactImage image,string url)
        {
            image.UpdateUrl(url);
        }

        public void RemoveImage(ArtifactImage image)
        {
            _artifactImages.Remove(image);
        }


        public void SetSafe(SafeId safeId)
        {
            SafeId = safeId;
        }

        public void SetTimePeriod(TimePeriodId timePeriodId)
        {
            TimePeriodId = timePeriodId;
        }

        private void SetMaterials(List<MaterialId> materialIds)
        {
            foreach (var materialId in materialIds)
            {
                var artifactMaterial = new ArtifactMaterial(this, materialId);

                if (artifactMaterial is not null)
                    _artifactMaterials.Add(artifactMaterial);
            }

        }

        public void AddMaterials(List<MaterialId> materialIds, MaterialId? importantMaterial = null)
        {
            SetMaterials(materialIds);

            if (importantMaterial is not null)
                SetImortantMaterial(importantMaterial);
        }


        public void UpdateMaterials(List<MaterialId> materialIds, MaterialId? importantMaterialId = null)
        {
            var materialToRemove = _artifactMaterials
                .Where(am => !materialIds.Contains(am.MaterialId)).ToList();

            if (materialToRemove.Count > 0)
                _artifactMaterials.RemoveAll(am => materialToRemove.Contains(am));

            var materialsToAdd = materialIds
                .Except(_artifactMaterials.Select(am => am.MaterialId)).ToList();

            if (materialsToAdd.Count != 0)
                SetMaterials(materialsToAdd);

            if (importantMaterialId is not null)
                UpdateImportantMaterial(importantMaterialId);
        }


        private void SetImortantMaterial(MaterialId materialId)
        {
            var artifactMaterial = _artifactMaterials
                .SingleOrDefault(x => x.MaterialId == materialId);

            artifactMaterial?.SetImportantMaterial();
        }


        private void UpdateImportantMaterial(MaterialId materialId)
        {
            var existImportantMaterial = _artifactMaterials
                .SingleOrDefault(am => am.IsImportantMaterial);

            existImportantMaterial?.UnSetImportantMaterial();

            SetImortantMaterial(materialId);
        }

    }

}
