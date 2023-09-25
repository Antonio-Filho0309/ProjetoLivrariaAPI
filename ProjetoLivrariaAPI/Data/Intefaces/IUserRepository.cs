using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Data.Intefaces
{
    public interface IUserRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        User[] GetAllUsers();
        User GetlUserById(int userId);


    }
}
