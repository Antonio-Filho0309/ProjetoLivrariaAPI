using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories.Intefaces;

namespace ProjetoLivrariaAPI.Repositories {
    public class UserRepository : IUserRepository {
        private readonly DataContext _context;

        public UserRepository(DataContext context) {
            _context = context;
        }

        public async Task<User> Add(User user) {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task Update(User user) {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user) {
            _context.Remove(user);
            await _context.SaveChangesAsync();

        }

        public async Task<ICollection<User>> GetAllUsers() {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int userId) {

            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User> GetUserByName(string userName) {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == userName);
        }

        //public void Add<T>(T entity) where T : class
        //{
        //    _context.Add(entity);
        //}

        //public void Update<T>(T entity) where T : class
        //{
        //    _context.Update(entity);
        //}

        //public void Delete<T>(T entity) where T : class
        //{
        //    _context.Remove(entity);
        //}

        //public bool SaveChanges()
        //{

        //    return _context.SaveChanges() > 0;
        //}

        //public User[] GetAllUsers()
        //{
        //    IQueryable<User> query = _context.Users;

        //    query = query.AsNoTracking().OrderBy(u => u.Id);

        //    return query.ToArray();
        //}

        //public User GetlUserById(int userId)
        //{
        //    IQueryable<User> query = _context.Users;

        //    query = query.AsNoTracking().OrderBy(u => u.Id)
        //        .Where(user => user.Id == userId);

        //    return query.FirstOrDefault();
        //}

        //public User GetlUserByName(string userName)
        //{
        //    IQueryable<User> query = _context.Users;

        //    query = query.AsNoTracking().OrderBy(u => u.Id)
        //        .Where(user => user.Name == userName);

        //    return query.FirstOrDefault();
        //}
    }
}
