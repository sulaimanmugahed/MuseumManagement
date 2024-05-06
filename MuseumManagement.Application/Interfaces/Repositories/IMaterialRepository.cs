using MuseumManagement.Domain.Materials;
using MuseumManagement.Domain.Materials.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Interfaces.Repositories
{
    public interface IMaterialRepository:IGenericEntityRepository<Material,MaterialId>
    {
    }
}
