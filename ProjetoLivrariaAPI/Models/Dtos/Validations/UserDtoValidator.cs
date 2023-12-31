﻿using FluentValidation;
using ProjetoLivrariaAPI.Models.Dtos.User;

namespace ProjetoLivrariaAPI.Models.Dtos.Validations
{
    //usar a create e a update 
    //criar outra classe dentro do namespace
    public class UserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()

                .WithMessage("Nome deve ser informado .")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty()

                .WithMessage("Email deve ser informado .")
                .EmailAddress()
                .WithMessage("Formato de email inválido .")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(250).WithMessage("Limite é de 250 caracteres.");


            RuleFor(u => u.City)
                .NotEmpty()

                .WithMessage("Cidade deve ser informada .")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");

            RuleFor(u => u.Address)
                .NotEmpty()

                .WithMessage("Endereço deve ser informado")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(250).WithMessage("Limite é de 250 caracteres.");
        }

    }

    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(u => u.Name)
               .NotEmpty()

               .WithMessage("Nome deve ser informado .")
               .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
               .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty()

                .WithMessage("Email deve ser informado .")
                .EmailAddress()
                .WithMessage("Formato de email inválido .")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(250).WithMessage("Limite é de 250 caracteres.");


            RuleFor(u => u.City)
                .NotEmpty()

                .WithMessage("Cidade deve ser informada .")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");

            RuleFor(u => u.Address)
                .NotEmpty()

                .WithMessage("Endereço deve ser informado")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(250).WithMessage("Limite é de 250 caracteres.");
        }
    }
}
