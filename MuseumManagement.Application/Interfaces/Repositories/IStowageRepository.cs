using MuseumManagement.Domain.Stowages;
using MuseumManagement.Domain.Stowages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Interfaces.Repositories
{
    public interface IStowageRepository:IGenericEntityRepository<Stowage, StowageId>
    {
    }
}
