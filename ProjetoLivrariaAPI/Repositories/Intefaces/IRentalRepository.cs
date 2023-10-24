using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Pagination;

namespace ProjetoLivrariaAPI.Repositories.Intefaces
{
    public interface IRentalRepository {
        Task<Rental> Add(Rental rental);
        Task Update(Rental rental);
        Task<ICollection<Rental>> GetAllRentals();
        Task<Rental> GetRentalById(int rentalId);

        Task<Rental> GetRentalByUserId(int UserId);

        Task<Rental> GetRentalByBookId(int BookId);

        Task<Rental> GetByUserAndBook(int userId, int bookId);

        Task<PagedBaseReponse<Rental>> GetAllRentalPaged(Filter rentalFilter);

    }
}
