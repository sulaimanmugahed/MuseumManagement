using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuseumManagement.Domain.TimePeriods.Entities;
using MuseumManagement.Domain.Artifacts;
using MuseumManagement.Domain.TimePeriods;

namespace MuseumManagement.Infrastructure.Persistence.Contexts.Configurations
{
    public class TimePeriodConfiguration : IEntityTypeConfiguration<TimePeriod>
    {
        public void Configure(EntityTypeBuilder<TimePeriod> builder)
        {
            builder.ToTable("TimePeriods", schema: "Main");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
              .HasConversion(
                id => id.Value,
                value => new TimePeriodId(value)
                ).HasMaxLength(36);
        }
    }
}

