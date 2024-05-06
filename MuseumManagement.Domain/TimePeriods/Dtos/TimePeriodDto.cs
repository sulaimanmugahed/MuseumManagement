using MuseumManagement.Domain.TimePeriods.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Domain.TimePeriods.Dtos
{
    public class TimePeriodDto
    {
        public TimePeriodDto()
        {

        }
        public TimePeriodDto(TimePeriod timePeriod)
        {
            Id = timePeriod.Id.Value;
            Name = timePeriod.Name;
        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
