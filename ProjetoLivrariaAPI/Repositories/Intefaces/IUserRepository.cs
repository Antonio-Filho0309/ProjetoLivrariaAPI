using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Repositories.Intefaces
{
    public interface IUserRepository
    {
        Task<User> Add (User user);
        Task Update (User user);
        void Delete(User user);

        Task <ICollection<User>> GetAllUsers();

       Task<User> GetUserById(int userId);

       Task<User> GetUserByName(string userName);


    }
}
