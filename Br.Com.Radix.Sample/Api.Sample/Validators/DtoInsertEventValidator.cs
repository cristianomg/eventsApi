using Api.Sample.Dtos;
using FluentValidation;

namespace Api.Sample.Validators
{
    public class DtoInsertEventValidator : AbstractValidator<DtoInsertEvent>
    {
        public DtoInsertEventValidator()
        {
            RuleFor(x => x.Value).NotNull().NotEmpty().WithMessage("O Valor não pode ser nulo ou vazio.");
            RuleFor(x => x.Tag).NotNull().NotEmpty().WithMessage("A tag não pode ser nula ou vazia.");
        }
    }
}
