using AutoMapper;
using ProjetoLivrariaAPI.Dtos.Book;
using ProjetoLivrariaAPI.Dtos.Rental;
using ProjetoLivrariaAPI.Dtos.Validations;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services.Interfaces;

namespace ProjetoLivrariaAPI.Services {
    public class RentalServices : IRentalService {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;

        public RentalServices(IMapper mapper, IRentalRepository rentalRepository) {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
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

            await _rentalRepository.Add(rental);
            return ResultService.ok(rental);
        }

        public async Task<ResultService> Update(UpdateRentalDto updateRentalDto) {
            if (updateRentalDto == null)
                return ResultService.Fail("Aluguel não encontrado");
            var validation = new UpdateRentalDtoValidator().Validate(updateRentalDto);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas com validação dos campos", validation);
            var book = await _rentalRepository.GetRentalById(updateRentalDto.Id);
            if (book == null)
                return ResultService.Fail("Aluguel não encontrado");
            book = _mapper.Map(updateRentalDto, book);
            await _rentalRepository.Update(book);
            return ResultService.ok("Aluguel atualizado com suceso !");
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
