using FluentValidation;
using XBank.Domain.Core.Requests;
using XBank.Domain.Shared.Util;
using XBank.Domain.Shared.Validators;

namespace XBank.Domain.Core.Validators
{
    public class AddAClientRequestValidator : AbstractValidator<AddClientRequest>
    {
        public AddAClientRequestValidator()
        {
            Include(new ClientRequestValidator());

            RuleFor(x => x.CPF)
                .NotEmpty()
                .NotNull()
                .Must(Validations.ValidateCPF)
				.WithMessage("InvalidCPF. Enter with valid CPF.");
        }

	}
}
