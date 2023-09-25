using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data.Intefaces;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Data {
    public class UserRepository : IUserRepository {
        private readonly DataContext _context;

        public UserRepository(DataContext context) {
            _context = context;
        }
        public void Add<T>(T entity) where T : class {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class {
            _context.Remove(entity);
        }

        public bool SaveChanges() {

            return (_context.SaveChanges() > 0);
        }

        public User[] GetAllUsers() {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking().OrderBy(u => u.Id);

            return query.ToArray();
        }

        public User GetlUserById(int userId) {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking().OrderBy(u => u.Id)
                .Where(user => user.Id == userId);

            return query.FirstOrDefault();
        }


    }
}
