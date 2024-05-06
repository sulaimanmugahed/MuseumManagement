using System;
using MuseumManagement.Domain.Materials;
using MuseumManagement.Domain.Materials.Entities;

namespace MuseumManagement.Domain.Artifacts.Entities
{
    public class ArtifactMaterial
    {
        private ArtifactMaterial() { }

        internal ArtifactMaterial(Artifact artifact, MaterialId materialId)
            : this()
            {
            Artifact = artifact;
            MaterialId = materialId;
           
        }

        public void UpdateMaterial(Material material)
        {
            Material = material;
        }

        public void SetImportantMaterial()
        {
            IsImportantMaterial = true;
        }

        public void UnSetImportantMaterial()
        {
            IsImportantMaterial = false;
        }

        public ArtifactId ArtifactId { get; private set; }
        public Artifact Artifact { get; private set; }

        public MaterialId MaterialId { get; private set; }
        public Material Material { get; private set; }
        public bool IsImportantMaterial { get; private set; }


    }
}
