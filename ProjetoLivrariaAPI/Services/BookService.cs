
using AutoMapper;
using ProjetoLivrariaAPI.Dtos.Book;
using ProjetoLivrariaAPI.Dtos.Validations;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services.Interfaces;

namespace ProjetoLivrariaAPI.Services {
    public class BookService : IBookService {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IMapper mapper, IBookRepository bookRepository) {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ICollection<BookDto>>> Get() {
            var books = await _bookRepository.GetAllBooks();
            return ResultService.ok(_mapper.Map<ICollection<BookDto>>(books));
        }

        public async Task<ResultService<BookDto>> GetById(int id) {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
                return ResultService.Fail<BookDto>("Livro não encontrado");
            return ResultService.ok(_mapper.Map<BookDto>(book));
        }
        public async Task<ResultService> Create(CreateBookDto createBookDto) {
            if (createBookDto == null)
                return ResultService.Fail<CreateBookDto>("Objeto deve ser informado !");

            var result = new BookDtoValidator().Validate(createBookDto);
            if (!result.IsValid)
                return ResultService.RequestError<CreateBookDto>("Problemas de validação: ", result);
            
            var book = _mapper.Map<Book>(createBookDto);

            await _bookRepository.Add(book);
            return ResultService.ok(book);
        }

        public async Task<ResultService> Update(UpdateBookDto updateBookDto) {
            if (updateBookDto == null)
                return ResultService.Fail("Livro não encontrado");
            var validation = new UpdateBookDtoValidator().Validate(updateBookDto);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas com validação dos campos", validation);
            var book = await _bookRepository.GetBookById(updateBookDto.Id);
            if (book == null)
                return ResultService.Fail("Livro não encontrado");
            book = _mapper.Map(updateBookDto, book);
            await _bookRepository.Update(book);
            return ResultService.ok("Livro atualizado com suceso !");

        }



        public async Task<ResultService> Delete(int id) {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
                return ResultService.Fail("Livro não encontrado");
            await _bookRepository.Delete(book);
            return ResultService.ok("Livro Deletado com sucesso");
        }


    }
}
