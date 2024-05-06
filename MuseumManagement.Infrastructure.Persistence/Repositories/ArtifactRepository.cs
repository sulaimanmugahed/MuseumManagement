using Microsoft.EntityFrameworkCore;
using MuseumManagement.Application.DTOs;
using MuseumManagement.Application.DTOs.Artifacts;
using MuseumManagement.Application.DTOs.Statistics;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Domain.Artifacts;

using MuseumManagement.Domain.Artifacts.Entities;

using MuseumManagement.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Infrastructure.Persistence.Repositories
{
    public class ArtifactRepository(ApplicationDbContext dbContext)
        : GenericEntityRepository<Artifact, ArtifactId>(dbContext),
        IArtifactRepository
    {

        private readonly DbSet<Artifact> _artifacts = dbContext.Set<Artifact>();


        public async Task<Artifact> GetArtifactDetailAsync(ArtifactId id)
        {
            var artifact = await _artifacts
                  .Include(a => a.ArtifactImages)   
                  .Include(a => a.Safe)
                  .Include(a => a.TimePeriod)
                  .Include(a => a.ArtifactMaterials)
                  .ThenInclude(ar => ar.Material)
                  .FirstOrDefaultAsync(a => a.Id == id);

            return artifact!;
        }

        public async Task<Artifact> GetArtifactWithIncludeAsync(Expression<Func<Artifact, bool>> criteria, string[] includes = null)
        {
            IQueryable<Artifact> query = _artifacts;

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return await query.SingleOrDefaultAsync(criteria);
        }

        public async Task<PagenationResponseDto<ArtifactDto>> GetPagedListAsync(int pageNumber, int pageSize, string serialNumber)
        {
            var query = _artifacts
                .OrderBy(a => a.Created)
                .AsQueryable();

            if (!string.IsNullOrEmpty(serialNumber))
            {
                query = query.Where(a => a.SerialNumber.ToString().Contains(serialNumber));
            }


            return await Paged(
                query.Select(a => new ArtifactDto(a)),
                pageNumber,
                pageSize);

        }

        //public async Task<PagedResult<ArtifactDto>> GetPagedListAsync(string searchValue, int? start, int? length, string sortColumn = null, string sortDirection = "ASC")
        //{

        //    var arifacts =  artifacts.Where(u =>
        //    u.IsDeleted == false).AsQueryable();

        //    if (!string.IsNullOrEmpty(searchValue))
        //    {
        //        arifacts = arifacts.Where(u =>
        //        u.Name.Contains(searchValue)
        //        || u.SerialNumber.ToString().Contains(searchValue)
        //        || u.OldMuseumNumber.Contains(searchValue)
        //        || u.NewMuseumNumber.Contains(searchValue)
        //        || u.Count.ToString().Contains(searchValue)
        //        );
        //    }

        //    int totalCount = await arifacts.CountAsync();

        //    if (!string.IsNullOrEmpty(sortColumn))
        //        if (sortDirection == "desc")
        //            arifacts = arifacts.OrderByDescending(a => EF.Property<object>(a, sortColumn));
        //        else
        //            arifacts = arifacts.OrderBy(a => EF.Property<object>(a, sortColumn));


        //    if (start.HasValue)
        //        arifacts = arifacts.Skip(start.Value);

        //    if (length.HasValue)
        //        arifacts = arifacts.Take(length.Value);

        //    return  new PagedResult<ArtifactDto>
        //    {
        //        Data = await arifacts.Select(a=> new ArtifactDto(a)).ToListAsync(),
        //        Draw = 1,
        //        RecordsFiltered = totalCount,
        //        RecordsTotal = totalCount,

        //    };

        //}


        public async Task<List<ArtifactStatisticsByTypeDto>> GetArtifactsCountGroupByType()
        {
            return await _artifacts
             .GroupBy(a => a.Type)
             .Select(t => new ArtifactStatisticsByTypeDto
             {
                 Type = t.Key,
                 ArtifactsCount = t.Count()
             }).ToListAsync();
        }

        public async Task<List<ArtifactStatisticsByConditionDto>> GetArtifactsCountGroupByCondition()
        {
            return await _artifacts
             .GroupBy(a => a.Condition)
             .Select(t => new ArtifactStatisticsByConditionDto
             {
                 Condition = t.Key,
                 ArtifactsCount = t.Count()
             }).ToListAsync();
        }

        public async Task<List<ArtifactStatisticsByBiodegradabilityDto>> GetArtifactsCountGroupByBiodegradability()
        {
            return await _artifacts
             .GroupBy(a => a.Biodegradability)
             .Select(t => new ArtifactStatisticsByBiodegradabilityDto
             {
                 Biodegradability = t.Key,
                 ArtifactsCount = t.Count()
             }).ToListAsync();
        }
    }
}
