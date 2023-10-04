using FluentValidation;
using ProjetoLivrariaAPI.Dtos.User;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Dtos.Validators {
    public class UserDtoValidator : AbstractValidator<UserDto> {
        public UserDtoValidator() {

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado !!");

            RuleFor(x => x.City)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cidade deve ser informada !!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email deve ser informado !!");

            RuleFor(x => x.Address)
                .NotEmpty()
                .NotNull()
                .WithMessage("Endereço deve ser informado !!");
               
                
        }
    }
}
