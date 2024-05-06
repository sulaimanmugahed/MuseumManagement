using MediatR;
using MuseumManagement.Application.DTOs;
using MuseumManagement.Application.DTOs.Artifacts;
using MuseumManagement.Application.Parameters;
using MuseumManagement.Application.Wrappers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Queries.GetArtifactPagedList
{
    public class GetArtifactPagedListQuery :PagenationRequestParameter ,IRequest<PagedResponse<ArtifactDto>>
    {
       public string SerialNumber { get; set; } 
    }
}
