using AutoMapper;
using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos;
using ProjetoLivrariaAPI.Models.Dtos.Validations;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Models.Dtos.Rental;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services.Interfaces;

namespace ProjetoLivrariaAPI.Services
{
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
            return ResultService.Ok(_mapper.Map<ICollection<RentalDto>>(rentals));
        }

        public async Task<ResultService<RentalDto>> GetById(int id) {
            var rental = await _rentalRepository.GetRentalById(id);
            if (rental == null)
                return ResultService.NotFound<RentalDto>("Aluguel não encontrado");
            return ResultService.Ok(_mapper.Map<RentalDto>(rental));

        }
        public async Task<ResultService> Create(CreateRentalDto createRentalDto) {
            if (createRentalDto == null)
                return ResultService.BadRequest("Objeto deve ser informado");
            var result = new RentalDtoValidator().Validate(createRentalDto);
            if (!result.IsValid)
                return ResultService.BadRequest(result);
            var rental = _mapper.Map<Rental>(createRentalDto);

            if (rental.RentalDate.Date != DateTime.Now.Date)
                return ResultService.BadRequest("A data de aluguel não pode ser diferente da data de hoje ");

            rental.Status = "Pendente";

            var sameRental = await _rentalRepository.GetByUserAndBook(createRentalDto.UserId, createRentalDto.BookId);
            if (sameRental != null)
                return ResultService.BadRequest("Usuário não pode alugar o mesmo livro");

            var bookQuantity = await _bookRepository.GetBookById(createRentalDto.BookId);

            if (bookQuantity == null) {
                return ResultService.NotFound("Livro não existe");
            }
            if (bookQuantity.Quantity == 0) {
                return ResultService.BadRequest("Livro sem estoque ");
            }

            bookQuantity.Rented++;
            bookQuantity.Quantity--;

            TimeSpan diference = rental.PreviewDate.Date - rental.RentalDate.Date;
            if (diference.TotalDays > 30)
                return ResultService.BadRequest("A data de previsão não pode ser mais de 30 dias após o aluguel");

            await _rentalRepository.Add(rental);
            return ResultService.Ok("Aluguel Criado com Sucesso");
        }

        public async Task<ResultService> Update(UpdateRentalDto updateRentalDto) {
            if (updateRentalDto == null)
                return ResultService.NotFound("Aluguel não encontrado");
            var validation = new UpdateRentalDtoValidator().Validate(updateRentalDto);
            if (!validation.IsValid)
                return ResultService.BadRequest(validation);
            var rental = await _rentalRepository.GetRentalById(updateRentalDto.Id);
            if (rental == null)
                return ResultService.NotFound("Aluguel não encontrado");
            rental = _mapper.Map(updateRentalDto, rental);

            if (rental.PreviewDate.Date >= rental.ReturnDate.Value.Date) {
                rental.Status = "No prazo";
            }
            else {
                rental.Status = "Atrasado";
            }

            var returnBook = await _bookRepository.GetBookById(rental.BookId);
            if (returnBook != null) {
                returnBook.Rented--;
                returnBook.Quantity++;
            }

            if (rental.ReturnDate.Value.Date != DateTime.Now.Date)
                return ResultService.BadRequest("A data de aluguel não pode ser diferente da data de hoje .");

            await _rentalRepository.Update(rental);
            return ResultService.Ok("Aluguel devolvido com Sucesso");
        }
        public async Task<ResultService<List<RentalDto>>> GetPagedAsync(Filter rentalFilter) {
            var rental = await _rentalRepository.GetAllRentalPaged(rentalFilter);
            var result = new PagedBaseResponseDto<RentalDto>(rental.TotalRegisters, rental.TotalPages, rental.PageNumber, _mapper.Map<List<RentalDto>>(rental.Data));

            if (result.Data.Count == 0)
                return ResultService.NotFound<List<RentalDto>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters, result.TotalPages, result.PageNumber);
        }

        public async Task<ResultService<List<RentalDashDto>>> GetDash()
        {
            var rentals = await _rentalRepository.GetAllRentals();
            return ResultService.Ok(_mapper.Map<List<RentalDashDto>>(rentals));
        }
    }
}
