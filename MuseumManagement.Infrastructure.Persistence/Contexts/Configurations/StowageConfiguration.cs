using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuseumManagement.Domain.Safes.Entities;
using MuseumManagement.Domain.Stowages;
using MuseumManagement.Domain.Stowages.Entities;
using MuseumManagement.Domain.TimePeriods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Infrastructure.Persistence.Contexts.Configurations
{
    public class StowageConfiguration: IEntityTypeConfiguration<Stowage>
    {
        public void Configure(EntityTypeBuilder<Stowage> builder)
        {
            builder.ToTable("Stowages", schema: "Main");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
              .HasConversion(
                id => id.Value,
                value => new StowageId(value)
                ).HasMaxLength(36);



        }
    }
}
