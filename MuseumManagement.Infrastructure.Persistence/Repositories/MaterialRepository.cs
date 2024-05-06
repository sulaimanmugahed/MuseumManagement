using Microsoft.EntityFrameworkCore;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Domain.Materials;
using MuseumManagement.Domain.Materials.Entities;
using MuseumManagement.Infrastructure.Persistence.Contexts;


namespace MuseumManagement.Infrastructure.Persistence.Repositories
{
    public class MaterialRepository(ApplicationDbContext dbContext)
        : GenericEntityRepository<Material, MaterialId>(dbContext),IMaterialRepository
    {
        private readonly DbSet<Material> materials = dbContext.Set<Material>();

    }
}
