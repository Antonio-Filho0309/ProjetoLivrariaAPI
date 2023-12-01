using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos.Book;
using ProjetoLivrariaAPI.Models.FilterDb;

namespace ProjetoLivrariaAPI.Services.Interfaces
{
    public interface IBookService {
        Task<ResultService<ICollection<BookDto>>> Get();
        Task<ResultService<BookDto>> GetById(int id);
        Task<ResultService> Create(CreateBookDto createBookDto);
        Task<ResultService> Update(UpdateBookDto updateBookDto);
        Task<ResultService> Delete(int id);

        Task<ResultService<ICollection<BookRentalDto>>> GetSelect();

        Task<ResultService<List<BookDto>>> GetPagedAsync(Filter bookFilter);

        Task<ResultService<List<RentedDashDto>>> GetRentedDash();
    }
}
