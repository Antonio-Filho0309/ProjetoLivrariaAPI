﻿
using AutoMapper;
using Locadora.API.Services;
using ProjetoLivrariaAPI.Dtos;
using ProjetoLivrariaAPI.Dtos.Book;
using ProjetoLivrariaAPI.Dtos.User;
using ProjetoLivrariaAPI.Dtos.Validations;
using ProjetoLivrariaAPI.FiltersDb;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services.Interfaces;

namespace ProjetoLivrariaAPI.Services {
    public class BookService : IBookService {
        private readonly IBookRepository _bookRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public BookService(IMapper mapper, IBookRepository bookRepository, IRentalRepository rentalRepository) {
            _bookRepository = bookRepository;
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ICollection<BookDto>>> Get() {
            var books = await _bookRepository.GetAllBooks();
            return ResultService.Ok(_mapper.Map<ICollection<BookDto>>(books));
        }

        public async Task<ResultService<BookDto>> GetById(int id) {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
                return ResultService.Fail<BookDto>("Livro não encontrado");
            return ResultService.Ok(_mapper.Map<BookDto>(book));
        }
        public async Task<ResultService> Create(CreateBookDto createBookDto) {
            if (createBookDto == null)
                return ResultService.Fail<CreateBookDto>("Objeto deve ser informado !");

            var result = new BookDtoValidator().Validate(createBookDto);
            if (!result.IsValid)
                return ResultService.RequestError(result);

            var book = _mapper.Map<Book>(createBookDto);

            //aqui é para dizer se  o livro do nome é o mesmo ou não
            var sameName = await _bookRepository.GetBookByName(createBookDto.Name);

            if (sameName != null) {
                return ResultService.Fail<BookDto>("Livro já cadastrado.");
            }

            if (createBookDto.Release > DateTime.Now.Year)
                return ResultService.Fail<CreateBookDto>("Ano de lançamento não pode ser maior que o ano atual");

            await _bookRepository.Add(book);
            return ResultService.Ok(book);
        }

        public async Task<ResultService> Update(UpdateBookDto updateBookDto) {
            if (updateBookDto == null)
                return ResultService.Fail("Livro não encontrado");
            var validation = new UpdateBookDtoValidator().Validate(updateBookDto);
            if (!validation.IsValid)
                return ResultService.RequestError(validation);
            var book = await _bookRepository.GetBookById(updateBookDto.Id);
            if (book == null)
                return ResultService.Fail("Livro não encontrado");
            book = _mapper.Map(updateBookDto, book);
            await _bookRepository.Update(book);
            return ResultService.Ok("Livro atualizado com suceso !");

        }



        public async Task<ResultService> Delete(int id) {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
                return ResultService.Fail("Livro não encontrado");
            var RentalAssociation = await _rentalRepository.GetRentalByBookId(id);
            if (RentalAssociation != null)
                return ResultService.Fail<User>("Erro ao excluir livro: Possui relação com alugueis");

            await _bookRepository.Delete(book);

            return ResultService.Ok("Livro Deletado com sucesso");
        }

        public async Task<ResultService<ICollection<BookRentalDto>>> GetSelect() {
           var book = await _bookRepository.GetAllBooks();
            return ResultService.Ok(_mapper.Map<ICollection<BookRentalDto>>(book));
        }

        public async Task<ResultService<List<BookDto>>> GetPagedAsync(Filter bookFilter) {
            var book = await _bookRepository.GetAllBookPaged(bookFilter);
            var result = new PagedBaseResponseDto<BookDto>(book.TotalRegisters, _mapper.Map<List<BookDto>>(book.Data));

            if (result.Data.Count == 0)
                return ResultService.Fail<List<BookDto>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters);
        }
    }
}
