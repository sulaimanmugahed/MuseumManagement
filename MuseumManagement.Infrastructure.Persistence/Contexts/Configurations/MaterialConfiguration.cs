using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuseumManagement.Domain.Materials.Entities;
using MuseumManagement.Domain.Artifacts;
using MuseumManagement.Domain.Materials;

namespace MuseumManagement.Infrastructure.Persistence.Contexts.Configurations
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Materials", schema: "Main");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
              .HasConversion(
                id => id.Value,
                value => new MaterialId(value)
                ).HasMaxLength(36);


          

        }
    }
}