using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Repositories.Intefaces {
    public interface IRentalRepository {
        Task<Rental> Add(Rental rental);
        Task Update(Rental rental);
        Task Delete(Rental rental);

        Task<ICollection<Rental>> GetAllRentals();
        Task<Rental> GetRentalById(int rentalId);


    }
}
