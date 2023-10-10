using FluentValidation;
using ProjetoLivrariaAPI.Dtos.Book;

namespace ProjetoLivrariaAPI.Dtos.Validations {
    public class BookDtoValidator : AbstractValidator<CreateBookDto> {
        public BookDtoValidator() {
            RuleFor(b => b.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado !")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");


            RuleFor(b => b.Author)
                .NotEmpty()
                .NotNull()
                .WithMessage("Autor deve ser informado !")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");

            RuleFor(b => b.PublisherId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Editora deve ser informada !");

            RuleFor(b => b.Release)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data de lançamento deve ser informada !");

            RuleFor(b => b.Quantity)
              .NotEmpty()
              .NotNull()
              .WithMessage("Data de lançamento deve ser informada !");
        }
    }

    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto> {
        public UpdateBookDtoValidator() {
            RuleFor(b => b.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado !")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");


            RuleFor(b => b.Author)
                .NotEmpty()
                .NotNull()
                .WithMessage("Autor deve ser informado !")
                .MinimumLength(3).WithMessage("Necessário pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Limite é de 50 caracteres.");


            RuleFor(b => b.PublisherId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Editora deve ser informada !");

            RuleFor(b => b.Release)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data de lançamento deve ser informada !");

            RuleFor(b => b.Quantity)
              .NotEmpty()
              .NotNull()
              .WithMessage("Data de lançamento deve ser informada !");
        }
    }
}
