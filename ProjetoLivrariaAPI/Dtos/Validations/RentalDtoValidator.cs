using FluentValidation;
using ProjetoLivrariaAPI.Dtos.Rental;

namespace ProjetoLivrariaAPI.Dtos.Validations {
    public class RentalDtoValidator : AbstractValidator<CreateRentalDto> {
        public RentalDtoValidator()
        {
            RuleFor(r => r.BookId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Livro deve ser informado !");

            RuleFor(r => r.UserId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Usuário deve ser informado !");

            RuleFor(r => r.RentalDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data de aluguel deve ser informada !");

            RuleFor(r => r.PreviewDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data de previsão de aluguel deve ser informado");
        }
    }

    public class UpdateRentalDtoValidator : AbstractValidator<UpdateRentalDto> {
        public UpdateRentalDtoValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Campo Id não informado.");
            RuleFor(x => x.ReturnDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Campo Data de Devolução não informado.");
        }
    }
}
