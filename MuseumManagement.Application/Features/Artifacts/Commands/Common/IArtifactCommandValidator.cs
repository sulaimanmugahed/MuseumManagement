using FluentValidation;
using MuseumManagement.Application.DTOs.Artifacts;
using MuseumManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Artifacts.Commands.Common
{
    public class IArtifactCommandValidator
: AbstractValidator<IArtifactCommand>
    {
        public IArtifactCommandValidator(ITranslator translator)
        {
            RuleFor(p => p.Name)
              .NotNull()
              .NotEmpty()
              .MaximumLength(100)
              .WithName(p => translator["Name"]);

            RuleFor(p => p.SerialNumber)
                .GreaterThanOrEqualTo(1)
                .LessThan(99999999)
                .WithName(p => translator["SerialNumber"]);


            //RuleFor(x => x.MaterialIds)
            //    .NotNull()
            //    .NotEmpty()
            //    .Must(BeUnique)
            //    .WithMessage(translator.GetString(TranslatorMessages.ArtifactMessages.Most_be_unique()));

            //RuleFor(x => x.ImportantMaterialId)
            //    .NotNull()
            //    .NotEmpty()
            //   .Must(ImportantMaterialInMaterial)
            //   .WithMessage(a => translator.GetString(TranslatorMessages.ArtifactMessages.ImportantMaterial_not_in_Materials(a.ImportantMaterialId.Value)));
        }

        //private bool BeUnique(List<MaterialId> values)
        //{
        //    return values.Distinct().Count() == values.Count();
        //}

        //private bool ImportantMaterialInMaterial(IArtifactDto model, MaterialId importantMaterial)
        //{
        //    if (model.MaterialIds.Contains(importantMaterial) || model.ImportantMaterialId.Value is null)
        //        return true;

        //    return false;
        //}
    }
}
