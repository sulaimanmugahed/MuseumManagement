using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuseumManagement.Domain.Artifacts;
using MuseumManagement.Domain.Artifacts.Entities;
using MuseumManagement.Domain.Safes;

namespace MuseumManagement.Infrastructure.Persistence.Contexts.Configurations
{
    public class ArtifactConfiguration : IEntityTypeConfiguration<Artifact>
    {
        public void Configure(EntityTypeBuilder<Artifact> builder)
        {
            builder
                .ToTable("Artifacts", schema: "Main");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
              .HasConversion(
                id => id.Value,
                value => new ArtifactId(value)
                ).HasMaxLength(36);

            builder
                .HasQueryFilter(a=> !a.IsDeleted);

            builder
                .Property(a => a.Condition)
                .IsRequired()
                .HasMaxLength(30)
                .HasConversion<string>();

            builder
                .Property(a => a.Biodegradability)
                .IsRequired()
                .HasMaxLength(30)
                .HasConversion<string>();

            builder
           .Property(a => a.Type)
           .IsRequired()
           .HasMaxLength(30)
           .HasConversion<string>();






            ///
            builder
              .HasOne(a => a.Safe)
              .WithMany(t => t.Artifacts)
              .HasForeignKey(a => a.SafeId)
              .OnDelete(DeleteBehavior.Restrict);


            /////
            builder
                    .HasMany(a => a.ArtifactImages)
                    .WithOne(i => i.Artifact)
                    .HasForeignKey(i => i.ArtifactId);

            ////
            builder.HasOne(a => a.TimePeriod)
              .WithMany(t => t.Artifacts)
              .HasForeignKey(a => a.TimePeriodId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
