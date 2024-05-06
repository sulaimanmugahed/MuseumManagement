using MuseumManagement.Domain.TimePeriods;
using MuseumManagement.Domain.TimePeriods.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Interfaces.Repositories
{
    public interface ITimePeriodRepository:IGenericEntityRepository<TimePeriod, TimePeriodId>
    {
    }
}
