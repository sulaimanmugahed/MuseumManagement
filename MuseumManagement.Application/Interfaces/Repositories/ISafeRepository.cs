using MuseumManagement.Domain.Safes;
using MuseumManagement.Domain.Safes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Interfaces.Repositories
{
    public interface ISafeRepository : IGenericEntityRepository<Safe,SafeId>
    {
    }
}
