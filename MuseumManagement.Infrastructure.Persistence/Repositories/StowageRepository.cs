using Microsoft.EntityFrameworkCore;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Domain.Stowages;
using MuseumManagement.Domain.Stowages.Entities;
using MuseumManagement.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Infrastructure.Persistence.Repositories
{
    public class StowageRepository(ApplicationDbContext dbContext)
        :GenericEntityRepository<Stowage,StowageId>(dbContext),
        IStowageRepository
    {
        private readonly DbSet<Stowage> _stowages = dbContext.Set<Stowage>(); 
    }
}
