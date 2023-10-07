using FluentValidation;
using ProjetoLivrariaAPI.Dtos.Publisher;
using ProjetoLivrariaAPI.Dtos.User;

namespace ProjetoLivrariaAPI.Dtos.Validations {
    public class PublisherDtoValidator : AbstractValidator<CreatePublisherDto> {
        public PublisherDtoValidator() {
            RuleFor(u => u.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado !");



            RuleFor(u => u.City)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cidade deve ser informada !");


        }

    }

    public class UpdatePublisherDtoValidator : AbstractValidator<UpdatePublisherDto> {
        public UpdatePublisherDtoValidator() {
            RuleFor(u => u.Name)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Nome deve ser informado !");



            RuleFor(u => u.City)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cidade deve ser informada !");


        }
    }
}
