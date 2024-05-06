using FluentValidation;
using MuseumManagement.Application.Features.Artifacts.Commands.Common;
using MuseumManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Commands.CreateArtifact
{
    public class CreateArtifactCommandValidator: AbstractValidator<CreateArtifactCommand>
    {
        public CreateArtifactCommandValidator(ITranslator translator)
        {
            Include(new IArtifactCommandValidator(translator));
        }

    }
}