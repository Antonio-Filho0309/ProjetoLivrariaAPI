using FluentValidation;
using ProjetoLivrariaAPI.Dtos.User;

namespace ProjetoLivrariaAPI.Dtos.Validations {
    public class UserDtoValidator : AbstractValidator<UserDto> {
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
