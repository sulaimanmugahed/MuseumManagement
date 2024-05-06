using MuseumManagement.Domain.Safes.Entities;
using MuseumManagement.Domain.Stowages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Domain.Stowages.Dtos
{
    public class StowageDto
    {
        public StowageDto()
        {

        }
        public StowageDto(Stowage stowage)
        {
            Id = stowage.Id.Value;
            Name = stowage.Name;
            Address = stowage.Address;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
    }
}
