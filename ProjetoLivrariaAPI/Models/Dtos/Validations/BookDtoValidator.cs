using FluentValidation;
using ProjetoLivrariaAPI.Models.Dtos.Book;

namespace ProjetoLivrariaAPI.Models.Dtos.Validations
{
    public class BookDtoValidator : AbstractValidator<CreateBookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty()

                .WithMessage("Nome deve ser informado .")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");


            RuleFor(b => b.Author)
                .NotEmpty()

                .WithMessage("Autor deve ser informado .")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");

            RuleFor(b => b.PublisherId)
                .NotEmpty()

                .WithMessage("Editora deve ser informada .");

            RuleFor(b => b.Release)
                .NotEmpty()

                .WithMessage("Ano de lançamento deve ser informado .");

            RuleFor(b => b.Quantity)
              .NotEmpty()
              .WithMessage("Quantidade não informada");
        }
    }

    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty()

                .WithMessage("Nome deve ser informado .")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");


            RuleFor(b => b.Author)
                .NotEmpty()

                .WithMessage("Autor deve ser informado .")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");


            RuleFor(b => b.PublisherId)
                .NotEmpty()

                .WithMessage("Editora deve ser informada .");

            RuleFor(b => b.Release)
                .NotEmpty()

                .WithMessage("Data de lançamento deve ser informada !");

            RuleFor(b => b.Quantity)
             .NotEmpty()
             .WithMessage("Quantidade não informada ou igual a 0.");
        }
    }
}
