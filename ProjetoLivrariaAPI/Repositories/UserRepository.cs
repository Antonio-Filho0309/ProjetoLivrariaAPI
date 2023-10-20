using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.FiltersDb;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Pagination;
using ProjetoLivrariaAPI.Repositories.Intefaces;

namespace ProjetoLivrariaAPI.Repositories
{
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

        public async Task<User> GetUserByEmail(string userEmail) {
            return await _context.Users.FirstOrDefaultAsync(u=> u.Email == userEmail);
        }

        public async Task<PagedBaseReponse<User>> GetAllUsersPaged(Filter userFilter) {
            var user = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(userFilter.Value)) 
                user = user.Where(u => u.Name.Contains(userFilter.Value) || u.Id.ToString().Contains(userFilter.Value) || u.Address.Contains(userFilter.Value) || u.City.Contains(userFilter.Value) || u.Email.Contains(userFilter.Value));

            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseReponse<User>,User> (user, userFilter);
        }
    }
}
