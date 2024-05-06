using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuseumManagement.Domain.Safes.Entities;
using MuseumManagement.Domain.Safes;
using MuseumManagement.Domain.Materials.Entities;
using MuseumManagement.Domain.Materials;
using MuseumManagement.Domain.Stowages;

namespace MuseumManagement.Infrastructure.Persistence.Contexts.Configurations
{
    public class SafeConfiguration : IEntityTypeConfiguration<Safe>
    {
        public void Configure(EntityTypeBuilder<Safe> builder)
        {
            builder.ToTable("Safes", schema: "Main");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
              .HasConversion(
                id => id.Value,
                value => new SafeId(value)
                ).HasMaxLength(36);

            builder
                .HasOne(s => s.Stowage)
                .WithMany(st=> st.Safes)
                .HasForeignKey(s => s.StowageId);


        
        }
    }
}
