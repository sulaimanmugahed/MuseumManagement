using Microsoft.EntityFrameworkCore;
using MuseumManagement.Infrastructure.Persistence.Contexts;
using System.IO;
using System.Threading.Tasks;

namespace MuseumManagement.Infrastructure.Persistence.Seeds
{
    public static class DefaultDatas
    {
        public static async Task SeedAsync(ApplicationDbContext applicationDbContext)
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "SqlDataSeed");

            if (Directory.Exists(dir))
            {
                foreach (var item in Directory.GetFiles(dir))
                {
                    var command = File.ReadAllText(item);
                    try
                    {
                        await applicationDbContext.Database.ExecuteSqlRawAsync(command);
                    }
                    catch
                    {
                    }
                }

                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
