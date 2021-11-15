using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Shared.Validators
{
    public class ClientRequestValidator: AbstractValidator<ClientRequest>
    {
        readonly Regex onlyLettersRegex = new Regex(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$");
        readonly Regex phoneRegex = new Regex(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$");

        public ClientRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .Matches(onlyLettersRegex);
            
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
                .Matches(phoneRegex)
                .WithMessage("Enter a phone in the format (xx) xxxx-xxxx");
        }
    }
}
