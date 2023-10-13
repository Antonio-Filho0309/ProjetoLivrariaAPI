using AutoMapper;
using ProjetoLivrariaAPI.Dtos.Book;
using ProjetoLivrariaAPI.Dtos.Rental;
using ProjetoLivrariaAPI.Dtos.Validations;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services.Interfaces;

namespace ProjetoLivrariaAPI.Services {
    public class RentalService : IRentalService {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public RentalService(IMapper mapper, IRentalRepository rentalRepository, IBookRepository bookRepository, IUserRepository userRepository) {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<ResultService<ICollection<RentalDto>>> Get() {

            var rentals = await _rentalRepository.GetAllRentals();
            return ResultService.ok(_mapper.Map<ICollection<RentalDto>>(rentals));
        }

        public async Task<ResultService<RentalDto>> GetById(int id) {
            var rental = await _rentalRepository.GetRentalById(id);
            if (rental == null)
                return ResultService.Fail<RentalDto>("Aluguel não encontrado");
            return ResultService.ok(_mapper.Map<RentalDto>(rental));

        }
        public async Task<ResultService> Create(CreateRentalDto createRentalDto) {
            if (createRentalDto == null)
                return ResultService.Fail<CreateRentalDto>("Objeto deve ser informado !");
            var result = new RentalDtoValidator().Validate(createRentalDto);
            if (!result.IsValid)
                return ResultService.RequestError<CreateRentalDto>("Problemas de validação: ", result);
            var rental = _mapper.Map<Rental>(createRentalDto);

            if (rental.RentalDate.Date != DateTime.Now.Date)
                return ResultService.Fail("A data de aluguel não pode ser diferente da data de hoje !");

            rental.Status = "Pendente";

            var sameRental = await _rentalRepository.GetByUserAndBook(createRentalDto.UserId, createRentalDto.BookId);
            if (sameRental != null && rental.Status == "Pendente")
                return ResultService.RequestError<CreateBookDto>(" O usuário não pode alugar o mesmo livro ! " , result);

            var bookQuantity = await _bookRepository.GetBookById(createRentalDto.BookId);
            if (bookQuantity != null) {
                bookQuantity.Rented++;
                bookQuantity.Quantity  --;
            }

            TimeSpan diference = rental.PreviewDate.Date - rental.RentalDate.Date;
            if (diference.TotalDays > 30)
                return ResultService.Fail("A data de previsão não pode ser mais de 30 dias após o aluguel !");

            await _rentalRepository.Add(rental);
            return ResultService.ok(rental);
        }

        public async Task<ResultService> Update(UpdateRentalDto updateRentalDto) {
            if (updateRentalDto == null)
                return ResultService.Fail("Aluguel não encontrado");
            var validation = new UpdateRentalDtoValidator().Validate(updateRentalDto);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas com validação dos campos", validation);
            var rental = await _rentalRepository.GetRentalById(updateRentalDto.Id);
            if (rental == null)
                return ResultService.Fail("Aluguel não encontrado");
            rental = _mapper.Map(updateRentalDto, rental);

            if (rental.PreviewDate.Date >= rental.ReturnDate.Date) {
                rental.Status = "No prazo";
            }else {
                rental.Status = "Atrasado";
            }

            var returnBook = await _bookRepository.GetBookById(rental.BookId);
            if (returnBook != null) {
                returnBook.Rented--;
                returnBook.Quantity++;
            }

            if (rental.ReturnDate.Date != DateTime.Now.Date)
                return ResultService.Fail("A data de aluguel não pode ser diferente da data de hoje !");

            await _rentalRepository.Update(rental);
            return ResultService.ok("Aluguel devolvido com suceso !");
        }

        public async Task<ResultService> Delete(int id) {
            var rental = await _rentalRepository.GetRentalById(id);
            if (rental == null)
                return ResultService.Fail("Aluguel não encontrado");
            await _rentalRepository.Delete(rental);
            return ResultService.ok("Aluguel deletado com sucesso");

        }




    }
}
