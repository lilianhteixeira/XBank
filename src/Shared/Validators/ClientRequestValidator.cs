using FluentValidation;
using System.Text.RegularExpressions;
using XBank.Domain.Shared.Requests;
using XBank.Domain.Shared.Util;

namespace XBank.Domain.Shared.Validators
{
    public class ClientRequestValidator: AbstractValidator<ClientRequest>
    {
        public ClientRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .Matches(RegexsMatches.onlyLettersRegex);
            
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
            
            RuleFor(x => x.Address)
                .NotEmpty()
                .NotNull();
            
            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .Matches(RegexsMatches.phoneRegex)
                .WithMessage("Enter a phone in the format (xx) xxxx-xxxx");
        }
    }
}
