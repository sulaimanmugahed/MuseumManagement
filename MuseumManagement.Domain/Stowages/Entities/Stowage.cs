using MuseumManagement.Domain.Artifacts.Entities;
using MuseumManagement.Domain.Common;
using MuseumManagement.Domain.Safes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Domain.Stowages.Entities
{
    public class Stowage
    {
        private readonly List<Safe> _safes = [];

        private Stowage()
        {

        }

        public IReadOnlyCollection<Safe> Safes
            => _safes;

        public Stowage(StowageId id, string name,string? address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
        public StowageId Id { get;private set; }
        public string Name { get; private set; }
        public string? Address { get; private set; }

        public void AddSafe(Safe safe)
        {
            safe.SetStowage(Id);
            _safes.Add(safe);
        }
    }
}
