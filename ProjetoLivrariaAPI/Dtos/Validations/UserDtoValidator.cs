using FluentValidation;
using ProjetoLivrariaAPI.Dtos.User;

namespace ProjetoLivrariaAPI.Dtos.Validations {
    //usar a create e a update 
    //criar outra classe dentro do namespace
    public class UserDtoValidator : AbstractValidator<CreateUserDto> {
        public UserDtoValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado !");

            RuleFor(u => u.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email deve ser informado !");

            RuleFor(u => u.City)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cidade deve ser informada !");

            RuleFor(u => u.Address)
                .NotEmpty()
                .NotNull()
                .WithMessage("Endereço deve ser informado");
        }
    }
}
