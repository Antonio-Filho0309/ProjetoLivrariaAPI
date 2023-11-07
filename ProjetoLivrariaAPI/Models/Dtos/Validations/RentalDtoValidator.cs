using FluentValidation;
using ProjetoLivrariaAPI.Models.Dtos.Rental;

namespace ProjetoLivrariaAPI.Models.Dtos.Validations
{
    public class RentalDtoValidator : AbstractValidator<CreateRentalDto>
    {
        public RentalDtoValidator()
        {
            RuleFor(r => r.BookId)
               .NotEmpty()

               .WithMessage("Livro deve ser informado .");

            RuleFor(r => r.UserId)
                .NotEmpty()

                .WithMessage("Usuário deve ser informado .");

            RuleFor(r => r.RentalDate)
                .NotEmpty()

                .WithMessage("Data de aluguel deve ser informada .");

            RuleFor(r => r.PreviewDate)
                .NotEmpty()

                .WithMessage("Data de previsão de aluguel deve ser informado");
        }
    }

    public class UpdateRentalDtoValidator : AbstractValidator<UpdateRentalDto>
    {
        public UpdateRentalDtoValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty()

                .WithMessage("Campo Id não informado.");
            RuleFor(x => x.ReturnDate)
                .NotEmpty()

                .WithMessage("Campo Data de Devolução não informado.");
        }
    }
}
