using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using System.Net;

namespace ProjetoLivrariaAPI.Repositories {
    public class RentalRepository : IRentalRepository {
        private readonly DataContext _context;

        public RentalRepository(DataContext context) {
            _context = context;
        }

        public async Task<Rental> Add(Rental rental) {
            _context.Add(rental);
            await _context.SaveChangesAsync();
            return rental;
        }

        public async Task Update(Rental rental) {
            _context.Update(rental);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Rental rental) {
            _context.Remove(rental);
            await _context.SaveChangesAsync();
        }



        public async Task<ICollection<Rental>> GetAllRentals() {
            return await _context.Rentals.Include(r => r.User)
                .Include(r => r.Book).ToListAsync();
        }

        public async Task<Rental> GetRentalById(int rentalId) {
            return await _context.Rentals.Include(r => r.Book).Include(r => r.User).FirstOrDefaultAsync(r => r.Id == rentalId);
        }



    }
}
