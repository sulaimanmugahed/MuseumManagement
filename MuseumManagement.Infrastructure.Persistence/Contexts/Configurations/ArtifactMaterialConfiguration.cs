﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuseumManagement.Domain.Artifacts.Entities;

namespace MuseumManagement.Infrastructure.Persistence.Contexts.Configurations
{
    internal class ArtifactMaterialConfiguration : IEntityTypeConfiguration<ArtifactMaterial>
    {
        public void Configure(EntityTypeBuilder<ArtifactMaterial> builder)
        {
            builder.ToTable("ArtifactMaterials", schema: "Main");

            //Set PrimaryKey(Composite)
            builder.HasKey(am => new { am.ArtifactId, am.MaterialId });

            builder.HasQueryFilter(am => !am.Artifact.IsDeleted);
            //RelationWithArtifact
            builder.HasOne(am => am.Artifact)
                .WithMany(a => a.ArtifactMaterials)
                .HasForeignKey(am => am.ArtifactId);

            //RelationWithMaterial
            builder.HasOne(am => am.Material)
                .WithMany()
                .HasForeignKey(am => am.MaterialId);

        }
    }
}

