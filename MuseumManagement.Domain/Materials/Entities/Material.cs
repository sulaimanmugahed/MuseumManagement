using MuseumManagement.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace MuseumManagement.Domain.Materials.Entities
{
    public sealed class Material
    {

        private Material()
        {

        }

        public Material(MaterialId id, string name)
        {
            Id = id;
            Name = name;
        }
        public MaterialId Id { get; private set; }
        public string Name { get; private set; }


    }
}
