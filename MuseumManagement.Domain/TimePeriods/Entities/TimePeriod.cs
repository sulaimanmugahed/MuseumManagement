using MuseumManagement.Domain.Artifacts.Entities;
using MuseumManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Domain.TimePeriods.Entities
{
    public class TimePeriod
    {
        private readonly List<Artifact> _artifacts = [];

        private TimePeriod()
        {
        }

        public TimePeriod(TimePeriodId id, string name)
        {
            Id = id;
            Name = name;
        }
        public TimePeriodId Id {  get; private set; }

        public string Name { get; private set; }

        public IReadOnlyCollection<Artifact> Artifacts =>
        _artifacts;
    }
}
