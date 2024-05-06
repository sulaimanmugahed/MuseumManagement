using Microsoft.EntityFrameworkCore;
using MuseumManagement.Domain.Materials;
using MuseumManagement.Domain.Materials.Entities;
using MuseumManagement.Domain.Safes;
using MuseumManagement.Domain.Safes.Entities;
using MuseumManagement.Domain.Stowages;
using MuseumManagement.Domain.Stowages.Entities;
using MuseumManagement.Domain.TimePeriods;
using MuseumManagement.Domain.TimePeriods.Entities;
using MuseumManagement.Infrastructure.Persistence.Contexts;
using System.Threading.Tasks;

namespace MuseumManagement.Infrastructure.Persistence.Seeds
{
    public static class DefaultData
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {

            if (!await dbContext.Stowages.AnyAsync())
            {
                dbContext.Stowages.Add(new Stowage(new StowageId("1"), "NotSet", "NotSet"));
                await dbContext.SaveChangesAsync();

            }

            if (!await dbContext.Safes.AnyAsync())
            {
                var safe1 = new Safe(new SafeId("1"), "NotSet");
                safe1.SetStowage(new StowageId("1"));
                dbContext.Safes.Add(safe1);
                await dbContext.SaveChangesAsync();

            }

           

            if (!await dbContext.Materials.AnyAsync())
            {
                dbContext.Materials.Add(new Material(new MaterialId("1"), "NotSet"));
                await dbContext.SaveChangesAsync();

            }

            if (!await dbContext.TimePeriods.AnyAsync())
            {
                dbContext.TimePeriods.Add(new TimePeriod(new TimePeriodId("1"), "NotSet"));
                await dbContext.SaveChangesAsync();

            }

        }
      

    }
}
