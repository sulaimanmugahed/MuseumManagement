using MuseumManagement.Application.DTOs;
using MuseumManagement.Application.DTOs.Artifacts;
using MuseumManagement.Application.DTOs.Statistics;
using MuseumManagement.Domain.Artifacts;

using MuseumManagement.Domain.Artifacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Interfaces.Repositories
{
    public interface IArtifactRepository:IGenericEntityRepository<Artifact, ArtifactId>
    {
        Task<Artifact> GetArtifactDetailAsync(ArtifactId id);
        Task<PagenationResponseDto<ArtifactDto>> GetPagedListAsync(int pageNumber, int pageSize, string serialNumber);
        //Task<PagedResult<ArtifactDto>> GetPagedListAsync(string searchValue, int? start, int? length, string sortColumn = null, string sortDirection = "ASC");
        Task<List<ArtifactStatisticsByTypeDto>> GetArtifactsCountGroupByType();
        Task<List<ArtifactStatisticsByConditionDto>> GetArtifactsCountGroupByCondition();
        Task<List<ArtifactStatisticsByBiodegradabilityDto>> GetArtifactsCountGroupByBiodegradability();
    }
}
