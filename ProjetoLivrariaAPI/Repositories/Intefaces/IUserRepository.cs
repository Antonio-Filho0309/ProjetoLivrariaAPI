using ProjetoLivrariaAPI.FiltersDb;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Repositories.Intefaces {
    public interface IUserRepository {
        Task<User> Add(User user);
        Task Update(User user);
        Task Delete(User user);

        Task<ICollection<User>> GetAllUsers();

        Task<User> GetUserById(int userId);

        Task<User> GetUserByName(string userName);

        Task<User> GetUserByEmail(string userEmail);

        Task<PagedBaseReponse<User>> GetAllUsersPaged(UserFilterDb request);


    }
}
