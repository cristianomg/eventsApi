using Api.Sample.Dtos;
using FluentValidation;

namespace Api.Sample.Validators
{
    public class DtoInsertEventValidator : AbstractValidator<DtoInsertEvent>
    {
        public DtoInsertEventValidator()
        {
            RuleFor(x => x.Tag).NotNull().NotEmpty().WithMessage("A tag não pode ser nula ou vazia.");
            RuleFor(x => x.Tag).Must(x=>x.Split('.').Length == 3).WithMessage("A tag não está no formato correto.");
        }
    }
}
