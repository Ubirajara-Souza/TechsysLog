using Bira.App.TechsysLog.Domain.Entities;
using FluentValidation;

namespace Bira.App.TechsysLog.Application.Validators
{
    public class RequestValidators : AbstractValidator<Request>
    {
        public RequestValidators()
        {
            RuleFor(f => f.Number)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.Description)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Value)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
