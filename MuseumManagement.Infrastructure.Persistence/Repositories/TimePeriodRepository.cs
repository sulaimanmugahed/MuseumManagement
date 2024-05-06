using Microsoft.EntityFrameworkCore;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Domain.TimePeriods;
using MuseumManagement.Domain.TimePeriods.Entities;
using MuseumManagement.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Infrastructure.Persistence.Repositories
{
    public class TimePeriodRepository(ApplicationDbContext dbContext)
        : GenericEntityRepository<TimePeriod, TimePeriodId>(dbContext),
        ITimePeriodRepository
    {
        private readonly DbSet<TimePeriod> timePeriods = dbContext.Set<TimePeriod>();



    }
}

