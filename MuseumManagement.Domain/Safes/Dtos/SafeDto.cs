using MuseumManagement.Domain.Safes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Domain.Safes.Dtos
{
    public class SafeDto
    {
        public SafeDto()
        {

        }
        public SafeDto(Safe safe)
        {
            Id = safe.Id.Value;
            Name = safe.Name;
        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
