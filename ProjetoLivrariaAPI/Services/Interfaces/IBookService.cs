using ProjetoLivrariaAPI.Dtos.Book;
namespace ProjetoLivrariaAPI.Services.Interfaces {
    public interface IBookService {
        Task<ResultService<ICollection<BookDto>>> Get();
        Task<ResultService<BookDto>> GetById(int id);
        Task<ResultService> Create(CreateBookDto createBookDto);
        Task<ResultService> Update(UpdateBookDto updateBookDto);
        Task<ResultService> Delete(int id);
    }
}
