﻿using MediatR;
using Microsoft.AspNetCore.Http;
using MuseumManagement.Application.DTOs.Artifacts;
using MuseumManagement.Application.Features.Artifacts.Commands.Common;
using MuseumManagement.Application.Wrappers;
using MuseumManagement.Domain.Artifacts;
using MuseumManagement.Domain.Artifacts.Enums;
using MuseumManagement.Domain.Materials;
using MuseumManagement.Domain.Safes;
using MuseumManagement.Domain.Stowages;
using MuseumManagement.Domain.TimePeriods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Commands.CreateArtifact
{
    public class CreateArtifactCommand: IRequest<BaseResult<ArtifactId>>, IArtifactCommand
    {
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public string? OldMuseumNumber { get; set; }
        public string? NewMuseumNumber { get; set; }
        public int Count { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public string? Note { get; set; }
        public string? ImageLink { get; set; }
        public ArtifactType Type { get; set; }
        public ArtifactCondition Condition { get; set; }
        public Biodegradability Biodegradability { get; set; }
        public string? ImportantMaterialId { get; set; }
        public List<string>? MaterialIds { get; set; }
        public string? SafeId { get; set; }
        public string? TimePeriodId { get; set; }
        public IFormFileCollection? ArtifactImages { get; set; }

        //public CreateArtifactDto CreateDto {  get; set; } 

    }
}
