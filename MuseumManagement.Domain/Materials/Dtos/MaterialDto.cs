using MuseumManagement.Domain.Materials.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Domain.Materials.Dtos
{
    public class MaterialDto
    {
        public MaterialDto()
        {

        }
        public MaterialDto(Material? material)
        {
            Id = material.Id.Value;
            Name = material.Name;
        }
        public string Id { get; set; }
        public string Name { get; set; }

    }
}
