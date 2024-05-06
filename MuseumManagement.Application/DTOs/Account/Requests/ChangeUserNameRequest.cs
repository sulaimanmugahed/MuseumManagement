using FluentValidation;
using MuseumManagement.Application.Helpers;
using MuseumManagement.Application.Interfaces;

namespace MuseumManagement.Application.DTOs.Account.Requests
{
    public class ChangeUserNameRequest
    {
        public string UserName { get; set; }
    }
    public class ChangeUserNameRequestValidator : AbstractValidator<ChangeUserNameRequest>
    {
        public ChangeUserNameRequestValidator(ITranslator translator)
        {
            RuleFor(x => x.UserName)
                .NotEmpty().NotNull()
                .MinimumLength(4)
                .Matches(Regexs.UserName)
                .WithName(translator["UserName"]);
        }
    }
}
