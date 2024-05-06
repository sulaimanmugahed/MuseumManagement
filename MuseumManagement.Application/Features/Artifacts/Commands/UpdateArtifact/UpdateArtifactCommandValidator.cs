using FluentValidation;
using MuseumManagement.Application.Features.Artifacts.Commands.Common;
using MuseumManagement.Application.Features.Artifacts.Commands.CreateArtifact;
using MuseumManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Commands.UpdateArtifact
{
    public class UpdateArtifactCommandValidator
 : AbstractValidator<UpdateArtifactCommand>
    {
        public UpdateArtifactCommandValidator(ITranslator translator)
        {
            Include(new IArtifactCommandValidator(translator));
        }

    }
}
