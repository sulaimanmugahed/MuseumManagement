using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Domain.Safes;
using MuseumManagement.Domain.Safes.Entities;
using MuseumManagement.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Infrastructure.Persistence.Repositories
{
    public class SafeRepository(ApplicationDbContext dbContext)
        :GenericEntityRepository<Safe,SafeId>(dbContext),
        ISafeRepository
    {
    }
}