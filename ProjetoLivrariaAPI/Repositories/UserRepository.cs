using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.FiltersDb;
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

        public async Task<User> GetUserByEmail(string userEmail) {
            return await _context.Users.FirstOrDefaultAsync(u=> u.Email == userEmail);
        }

        public async Task<PagedBaseReponse<User>> GetAllUsersPaged(UserFilterDb request) {
            var user = _context.Users.AsQueryable();
            if (string.IsNullOrEmpty(request.Name)) 
                user = user.Where(u => u.Name.Contains(request.Name));

            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseReponse<User>,User> (user, request);
        }
    }
}
