using ApiGestion.DTOS.Request;
using FluentValidation;
namespace ApiGestion.Validatins

{
    public class CreateDueñoValidator : AbstractValidator<CreateDTO>
    {
       public CreateDueñoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotNull().NotEmpty().MaximumLength(30).WithMessage("El nombre no puede estar vacio");
            RuleFor(X => X.Email)
                .NotEmpty();
            RuleFor(c => c.Telefono)
               .NotNull();
            RuleFor(c => c.Dni)
                .NotEmpty().WithMessage("No puede estar vacio");
            RuleFor(c => c.Direccion)
                .NotEmpty();
        }
    }
}
