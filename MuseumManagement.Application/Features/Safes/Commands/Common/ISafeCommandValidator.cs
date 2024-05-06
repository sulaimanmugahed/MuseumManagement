using FluentValidation;
using MuseumManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Features.Safes.Commands.Common
{
    public class ISafeCommandValidator:AbstractValidator<ISafeCommand>
    {
        public ISafeCommandValidator(ITranslator translator)
        {
            RuleFor(s => s.Name)
                 .NotNull()
                 .NotEmpty()
                 .WithName(translator["Name"]);
                
        }
    }
}
