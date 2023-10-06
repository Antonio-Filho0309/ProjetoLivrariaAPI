using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Repositories.Intefaces
{
    public interface IRentalRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Rental[] GetAllRentals(bool includeUser = false, bool includeBook = false);
        Rental GetRentalById(int rentalId, bool includeUser = false, bool includeBook = false);


    }
}
