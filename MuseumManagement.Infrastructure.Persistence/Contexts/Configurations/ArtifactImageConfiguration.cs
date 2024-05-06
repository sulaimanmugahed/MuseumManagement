using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuseumManagement.Domain.Artifacts;
using MuseumManagement.Domain.Artifacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Infrastructure.Persistence.Contexts.Configurations
{
    public class ArtifactImageConfiguration : IEntityTypeConfiguration<ArtifactImage>
    {
        public void Configure(EntityTypeBuilder<ArtifactImage> builder)
        {
            builder.ToTable("ArtifactImages", schema: "Main");

            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(i => !i.Artifact.IsDeleted);
            builder.Property(s => s.Id)
             .HasConversion(
               id => id.Value,
               value => new ArtifactImageId(value)
               ).HasMaxLength(36);

          

        }
    }
}
