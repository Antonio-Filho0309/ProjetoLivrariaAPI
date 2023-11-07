using FluentValidation;
using ProjetoLivrariaAPI.Models.Dtos.User;
using ProjetoLivrariaAPI.Models.Dtos.Publisher;

namespace ProjetoLivrariaAPI.Models.Dtos.Validations
{
    public class PublisherDtoValidator : AbstractValidator<CreatePublisherDto>
    {
        public PublisherDtoValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()

                .WithMessage("Nome deve ser informado .")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");



            RuleFor(u => u.City)
                .NotEmpty()

                .WithMessage("Cidade deve ser informada .")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");


        }

    }

    public class UpdatePublisherDtoValidator : AbstractValidator<UpdatePublisherDto>
    {
        public UpdatePublisherDtoValidator()
        {
            RuleFor(u => u.Name)
                    .NotEmpty()

                    .WithMessage("Nome deve ser informado .")
                    .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                    .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");



            RuleFor(u => u.City)
                .NotEmpty()

                .WithMessage("Cidade deve ser informada .")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");


        }
    }
}
