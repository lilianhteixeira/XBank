using FluentValidation;
using XBank.Domain.Core.Requests;
using XBank.Domain.Shared.Util;

namespace XBank.Domain.Core.Validators
{
    class AddMovementRequestValidator : AbstractValidator<AddMovementRequest>
    {
        public AddMovementRequestValidator()
        {
            RuleFor(x => x.MovementValue)
                .GreaterThan(0)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Type)
                .IsInEnum()
                .NotEmpty()
                .NotNull();
        }
    }
}
